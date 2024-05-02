using master_bppm.Interfaces;
using master_bppm.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;


namespace master_bppm.Repository
{
    public class MasterBPPM : IMasterBPPM
    {
        private readonly SQLContext _context;
        private readonly DBContext _Oracontext;
        private readonly string serverFilePath = @"C:\UploadFile\Images";
        public MasterBPPM(DBContext Oracontext, SQLContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _Oracontext = Oracontext;
        }

        public async Task<IEnumerable<MasterDataDto>> GetMasterDataByIdRepo(string nik)
        {
            //Filter by user auth organizations
            var userOrganizations = await _Oracontext.XXB7_ESS_BPPM_ORACLE_USER_V
                .Where(user =>
                    user.EMPLOYEE_NUMBER.StartsWith("KF-")
                        ? user.EMPLOYEE_NUMBER.Substring(3) == nik 
                        : user.EMPLOYEE_NUMBER == nik)
                .Select(user => user.ORGANIZATION_CODE)
                .ToListAsync();

            var masterDataQuery = await _context.XXB7_ESS_BPPM_MASTER_DATA
                .Where(masterItem => userOrganizations.Contains(masterItem.ORGANIZATION))
                .Select(masterItem => new
                {
                    masterItem.ORGANIZATION,
                    masterItem.ORACLE_ITEM_CODE,
                    masterItem.ORACLE_ITEM_DESCRIPTION,
                    masterItem.BPPM_ITEM_ID,
                    masterItem.LOCATION,
                    masterItem.PHOTO_URL,
                    masterItem.DETAILS,
                    masterItem.UOM,
                    masterItem.MACHINE,
                    masterItem.STATUS
                })
                .ToListAsync();

            var oracleDataQuery = await _Oracontext.XXB7_ESS_BPPM_ORACLE_DATA_V
                .Select(oracleItem => new
                {
                    oracleItem.ORACLE_ITEM_DESCRIPTION,
                    oracleItem.ORACLE_ITEM_CODE,
                    oracleItem.UNIT_PRICE,
                    oracleItem.UOM,
                    oracleItem.MIN_QTY,
                    oracleItem.MAX_QTY,
                    oracleItem.USAGE_PER_YEAR,
                    oracleItem.AVAILABILITY,
                    oracleItem.ORGANIZATION
                })
                .ToListAsync();

            Console.WriteLine($"Master Data Count: {masterDataQuery.Count}");
            Console.WriteLine($"Oracle Data Count: {oracleDataQuery.Count}");

            //Inner Left Join
            var data = (from masterItem in masterDataQuery
                        join oracleItem in oracleDataQuery
                        on new { masterItem.ORACLE_ITEM_CODE, masterItem.ORGANIZATION }
                        equals new { oracleItem.ORACLE_ITEM_CODE, oracleItem.ORGANIZATION }
                        into oracleItems
                        from oracleItem in oracleItems.DefaultIfEmpty()
                        select new MasterDataDto
                        {
                            BPPM_ITEM_ID = masterItem.BPPM_ITEM_ID,
                            LOCATION = masterItem.LOCATION,
                            PHOTO_URL = masterItem.PHOTO_URL,
                            ORACLE_ITEM_DESCRIPTION = oracleItem != null ? oracleItem.ORACLE_ITEM_DESCRIPTION : masterItem.ORACLE_ITEM_DESCRIPTION,
                            ORACLE_ITEM_CODE = oracleItem != null ? oracleItem.ORACLE_ITEM_CODE : masterItem.ORACLE_ITEM_CODE,
                            DETAILS = masterItem.DETAILS,
                            UOM = oracleItem != null ? oracleItem.UOM : masterItem.UOM,
                            MACHINE = masterItem.MACHINE,
                            ORGANIZATION = oracleItem != null ? oracleItem.ORGANIZATION : masterItem.ORGANIZATION,
                            STATUS = masterItem.STATUS,
                            AVAILABILITY = oracleItem != null ? oracleItem.AVAILABILITY : 0
                        }).ToList();

            //Console.WriteLine($"Joined Data Count: {data.Count}");

               
            return data;
        }





        public async Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> EditMasterDataRepo(int bppmItemId, string user, XXB7_ESS_BPPM_MASTER_DATA request)
        {

            string filename = "";
            

            try
            {
                var existingItemSQL = await _context.XXB7_ESS_BPPM_MASTER_DATA.FindAsync(bppmItemId);
                //var existingItem = await _Oracontext.XXB7_ESS_BPPM_ORACLE_DATA_V.FirstOrDefaultAsync(item => item.ORACLE_ITEM_ID == );


                if (existingItemSQL == null)
                {
                    throw new ArgumentException("Item Does Not Exist");
                }

                string action = "";

                string editedStatus = request.STATUS?.Trim();
                string existingStatus = existingItemSQL.STATUS?.Trim();

                if (string.Equals(editedStatus, "ACTIVE", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(existingStatus, "ACTIVE", StringComparison.OrdinalIgnoreCase))
                {
                    action = "ACTIVE";
                    existingItemSQL.STATUS = "Active";
                }
                else if (string.Equals(editedStatus, "DEACTIVE", StringComparison.OrdinalIgnoreCase) &&
                         !string.Equals(existingStatus, "DEACTIVE", StringComparison.OrdinalIgnoreCase))
                {
                    action = "DEACTIVE";
                    existingItemSQL.STATUS = "Deactive";
                }
                else if (string.Equals(editedStatus, existingStatus, StringComparison.OrdinalIgnoreCase))
                {
                    action = "EDIT";
                }
                else
                {
                    throw new ArgumentException("Status Cannot Be Empty");
                }

                existingItemSQL.LOCATION = request.LOCATION;
                existingItemSQL.MACHINE = request.MACHINE;
                existingItemSQL.DETAILS = request.DETAILS;
                //existingItem.PHOTO_URL = request.PHOTO_URL; save to db
                existingItemSQL.USER = user;
                //existingItem.PHOTO_DATA = request.PHOTO_URL;


                //BASE64
                if (!string.IsNullOrEmpty(request.PHOTO_URL))
                {
                    if (request.PHOTO_URL.StartsWith("http"))
                    {
                        existingItemSQL.PHOTO_URL = request.PHOTO_URL;
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            string photo = request.PHOTO_URL;
                            string resultPhoto = Regex.Replace(photo, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);

                            //int lastHyphenIndex = existingItemSQL.PHOTO_URL.LastIndexOf('-');
                            //int lastDotIndex = existingItemSQL.PHOTO_URL.LastIndexOf('.');

                            //if (lastHyphenIndex >= 0 && lastDotIndex >= 0)
                            //{
                            //    string numericPart = existingItemSQL.PHOTO_URL.Substring(lastHyphenIndex + 1, lastDotIndex - lastHyphenIndex - 1);

                            //    if (int.TryParse(numericPart, out int inc))
                            //    {
                            //        // Increment the extracted integer by 1
                            //        int count = inc + 1;

                            //        // Construct the new filename
                            //        filename = "gambar-bppm-" + existingItemSQL.BPPM_ITEM_ID + "-" + count.ToString() + ".jpg";
                            //    }
                            //    else
                            //    {
                            //        throw new ArgumentException("Error When Saving Image");
                            //    }
                            //}
                            //else
                            //{
                            //    filename = "gambar-bppm-" + existingItemSQL.BPPM_ITEM_ID + "-1" + ".jpg";
                            //}

                            byte[] imageData = Convert.FromBase64String(resultPhoto);
                            using (var inStream = new MemoryStream(imageData))
                            using (var outStream = new MemoryStream())
                            {
                                // Load the image using ImageSharp
                                using (var image = Image.Load(inStream))
                                {
                                    // Check the original size
                                    long originalSize = inStream.Length;
                                    Console.WriteLine("Original Image Size: " + originalSize + " bytes");

                                    // Set default quality for <1MB images
                                    int quality = 100;

                                    // If more than 1MB, compress
                                    if (originalSize > 1 * 1024 * 1024)
                                    {
                                        quality = 50;

                                        var encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder
                                        {
                                            Quality = quality 
                                        };
                                        image.SaveAsJpeg(outStream, encoder);
                                    }
                                    else
                                    {
                                        image.SaveAsJpeg(outStream);
                                    }
                                }

                                byte[] compressedImageData = outStream.ToArray();

                                // Check compressed size
                                long compressedSize = outStream.Length;
                                Console.WriteLine("Compressed Image Size: " + compressedSize + " bytes");

                                Dictionary<string, object> Transdata = new Dictionary<string, object>()
                                    {
                                        {"File", compressedImageData},
                                        {"FolderPath", "ESSBPPM" },
                                        {"Filename", filename },
                                    };

                                try
                                {
                                    HttpResponseMessage Res = await client.PostAsJsonAsync("https://portal.bintang7.com/APIUpload/UploadFile64", Transdata);
                                    //dynamic response = await Res.Content.ReadAsAsync<JObject>();
                                    if (Res.IsSuccessStatusCode)
                                    {
                                        string responseContent = await Res.Content.ReadAsStringAsync();
                                        JObject response = JObject.Parse(responseContent);

                                        if (response.TryGetValue("Filepath", out var filepathValue) && filepathValue.Type == JTokenType.String)
                                        {
                                            existingItemSQL.PHOTO_URL = filepathValue.Value<string>();
                                        }
                                    }
                                    else
                                    {
                                        existingItemSQL.PHOTO_URL = "No Photo";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error: " + ex.Message);
                                    throw new ArgumentException("Image Invalid");
                                }
                            }
                        }
                    }
                }


                else
                {
                    existingItemSQL.PHOTO_URL = "No Photo";
                }

                // Log entry for LOG_MASTER_DATA
                var logEntry = new XXB7_ESS_BPPM_LOG_MASTER_DATA
                {
                    BPPM_ITEM_ID = existingItemSQL.BPPM_ITEM_ID,
                    TIME_STAMP = DateTime.Now,
                    USER = user,
                    ORACLE_ITEM_ID = existingItemSQL.ORACLE_ITEM_ID,
                    ORGANIZATION = existingItemSQL.ORGANIZATION,
                    ORACLE_ITEM_CODE = existingItemSQL.ORACLE_ITEM_CODE,
                    ORACLE_ITEM_DESCRIPTION = existingItemSQL.ORACLE_ITEM_DESCRIPTION,
                    UOM = existingItemSQL.UOM,
                    LOCATION = request.LOCATION,
                    MACHINE = request.MACHINE,
                    PHOTO_URL = existingItemSQL.PHOTO_URL,
                    DETAILS = request.DETAILS,
                    STATUS = action
                };

                

                _context.Update(existingItemSQL); 
                //_context.Update(existingItemSQL); 
                _context.Add(logEntry); 
                await _context.SaveChangesAsync();


                //return await _context.XXB7_ESS_BPPM_MASTER_DATA.Where(item => item.BPPM_ITEM_ID == bppmItemId).ToListAsync();
                return await _context.XXB7_ESS_BPPM_MASTER_DATA.Where(item => item.BPPM_ITEM_ID == bppmItemId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }


        public async Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> UpdateAvailabilityDataRepo(string itemCode, string organization)
        {
            var sqlMasterData = await _context.XXB7_ESS_BPPM_MASTER_DATA
                .Where(item => item.ORACLE_ITEM_CODE == itemCode && item.ORGANIZATION == organization)
                .FirstOrDefaultAsync();

            var oracleData = await _Oracontext.XXB7_ESS_BPPM_ORACLE_DATA_V
                .Where(item => item.ORACLE_ITEM_CODE == itemCode && item.ORGANIZATION == organization)
                .FirstOrDefaultAsync();

            if (sqlMasterData != null && oracleData != null)
            {
                int? sqlAvailability = sqlMasterData.AVAILABILITY; // Nullable int
                int? oracleAvailability = oracleData.AVAILABILITY; // Nullable int

                if (sqlAvailability.HasValue && oracleAvailability.HasValue)
                {
                    int difference = oracleAvailability.Value - sqlAvailability.Value;

                    sqlMasterData.AVAILABILITY += difference;


                   // await _context.SaveChangesAsync();
                }
            }

            // Return updated master data (or any other appropriate data)
            return Enumerable.Empty<XXB7_ESS_BPPM_MASTER_DATA>(); // Placeholder, replace with actual data
        }


    }

}

