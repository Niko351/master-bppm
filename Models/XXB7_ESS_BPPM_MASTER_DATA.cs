using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace master_bppm.Models
{
    public class XXB7_ESS_BPPM_MASTER_DATA
    {
        [Key]
        [JsonProperty(PropertyName = "BPPM_ITEM_ID")]
        public int BPPM_ITEM_ID { get; set; }

        [ForeignKey("ORACLE_ITEM_ID")]
        [JsonProperty(PropertyName = "ORACLE_ITEM_ID")]
        public int ORACLE_ITEM_ID { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        [JsonProperty(PropertyName = "ORGANIZATION")]
        public string ORGANIZATION { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(40)]
        [JsonProperty(PropertyName = "ORACLE_ITEM_CODE")]
        public string? ORACLE_ITEM_CODE { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(240)]
        [JsonProperty(PropertyName = "ORACLE_ITEM_DESCRIPTION")]
        public string? ORACLE_ITEM_DESCRIPTION { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        [JsonProperty(PropertyName = "UOM")]
        public string? UOM { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [JsonProperty(PropertyName = "LOCATION")]
        public string? LOCATION { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [JsonProperty(PropertyName = "MACHINE")]
        public string? MACHINE { get; set; }

        [JsonProperty(PropertyName = "PHOTO_URL")]
        public string? PHOTO_URL { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [JsonProperty(PropertyName = "DETAILS")]
        public string? DETAILS { get; set; }

        [JsonProperty(PropertyName = "UNIT_PRICE")]
        public int? UNIT_PRICE { get; set; }

        [JsonProperty(PropertyName = "AVAILABILITY")]
        public int? AVAILABILITY { get; set; }

        [JsonProperty(PropertyName = "MIN_QTY")]
        public int? MIN_QTY { get; set; }

        [JsonProperty(PropertyName = "MAX_QTY")]
        public int? MAX_QTY { get; set; }

        [JsonProperty(PropertyName = "USAGE_PER_YEAR")]
        public int? USAGE_PER_YEAR { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [JsonProperty(PropertyName = "STATUS")]
        public string STATUS { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "USER")]
        public string USER { get; set; }

        //[NotMapped]
        //[JsonProperty(PropertyName = "UPLOAD_PHOTO")]
        //public IFormFile? FILE { get; set; }

        //[NotMapped]
        //[JsonProperty(PropertyName = "FILE_NAME")]
        //public IFormFile FILENAME { get; set; }

        //[NotMapped]
        //[JsonProperty(PropertyName = "FILE_PATH")]
        //public string FILEPATH { get; set; }
        //[NotMapped]
        //[JsonProperty(PropertyName = "PHOTO_DATA")]
        //public string? PHOTO_DATA { get; set; }

    }

    public class MasterDataDto
    {
        [JsonProperty(PropertyName = "BPPM_ITEM_ID")]
        public int BPPM_ITEM_ID { get; set; }

        [JsonProperty(PropertyName = "ORACLE_ITEM_CODE")]
        public string? ORACLE_ITEM_CODE { get; set; }
        [JsonProperty(PropertyName = "ORACLE_ITEM_DESCRIPTION")]
        public string? ORACLE_ITEM_DESCRIPTION { get; set; }

        [JsonProperty(PropertyName = "UOM")]
        public string? UOM { get; set; }

        [JsonProperty(PropertyName = "LOCATION")]
        public string? LOCATION { get; set; }

        [JsonProperty(PropertyName = "MACHINE")]
        public string? MACHINE { get; set; }

        [JsonProperty(PropertyName = "PHOTO_URL")]
        public string? PHOTO_URL { get; set; }

        [JsonProperty(PropertyName = "PHOTO_DATA")]
        public string? PHOTO_DATA { get; set; }


        [JsonProperty(PropertyName = "DETAILS")]
        public string? DETAILS { get; set; }
        [JsonProperty(PropertyName = "ORGANIZATION")]
        public string ORGANIZATION { get; set; }

        [JsonProperty(PropertyName = "STATUS")]
        public string STATUS { get; set; }

        [JsonProperty(PropertyName = "AVAILABILITY")]
        public int? AVAILABILITY { get; set; }
    }

}

