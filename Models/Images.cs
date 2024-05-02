using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace master_bppm.Models
{
    public class Images
    {
        [JsonProperty(PropertyName = "FormFile")]
        public IFormFile? FormFile { get; set; }

        [JsonProperty(PropertyName = "FILE_NAME")]
        public string Filename { get; set; }

        [JsonProperty(PropertyName = "FOLDER_PATH")]
        public string FolderPath { get; set; }

        //public string FilePath { get; set; }

    }
}
