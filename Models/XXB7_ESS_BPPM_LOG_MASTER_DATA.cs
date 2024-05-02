using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace master_bppm.Models
{
    public class XXB7_ESS_BPPM_LOG_MASTER_DATA
    {
        [ForeignKey("BPPM_ITEM_ID")]
        [JsonProperty(PropertyName = "BPPM_ITEM_ID")]
        public int BPPM_ITEM_ID { get; set; }


        [Key]
        [JsonProperty(PropertyName = "LOG_MASTER_DATA_ID")]
        public int LOG_MASTER_DATA_ID { get; set; }

        [JsonProperty(PropertyName = "TIME_STAMP")]
        public DateTime TIME_STAMP { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [JsonProperty(PropertyName = "USER")]
        public string USER { get; set; }

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

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [JsonProperty(PropertyName = "STATUS")]
        public string STATUS { get; set; }

    }

    public class MasterLogDto
    {
        public DateTime TIME_STAMP { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string STATUS { get; set; }
        public string? ORACLE_ITEM_CODE { get; set; }
        public string? ORACLE_ITEM_DESCRIPTION { get; set; }
        public string? UOM { get; set; }
        public string? LOCATION { get; set; }
        public string? MACHINE { get; set; }
        public string? PHOTO_URL { get; set; }
        public string? DETAILS { get; set; }
        public string USER { get; set; }
    }
}
