using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace master_bppm.Models
{
    [Table("XXB7_ESS_BPPM_ORACLE_DATA_V")]
    public class XXB7_ESS_BPPM_ORACLE_DATA_V
    {
        [Key]
        public int ORACLE_ITEM_ID { get; set; }
        public int ORG_ID { get; set; }
        public string ORGANIZATION { get; set; }
        public int? AVAILABILITY { get; set; }
        public int? MIN_QTY { get; set; }
        public int? MAX_QTY { get; set; }
        public int? USAGE_PER_YEAR { get; set; }
        public int? UNIT_PRICE { get; set; }
        public string? UOM { get; set; }
        public string? ORACLE_ITEM_CODE { get; set; }
        public string? ORACLE_ITEM_DESCRIPTION { get; set; }
    }

    public class SparepartInventoryDto
    {
        [JsonProperty(PropertyName = "ORACLE_ITEM_CODE")]
        public string? ORACLE_ITEM_CODE { get; set; }
        [JsonProperty(PropertyName = "AVAILABILITY")]
        public int? AVAILABILITY { get; set; }
        [JsonProperty(PropertyName = "MIN_QTY")]
        public int? MIN_QTY { get; set; }
        [JsonProperty(PropertyName = "MAX_QTY")]
        public int? MAX_QTY { get; set; }
        [JsonProperty(PropertyName = "USAGE_PER_YEAR")]
        public int? USAGE_PER_YEAR { get; set; }
        [JsonProperty(PropertyName = "UNIT_PRICE")]
        public int? UNIT_PRICE { get; set; }
        [JsonProperty(PropertyName = "ORACLE_ITEM_DESCRIPTION")]
        public string? ORACLE_ITEM_DESCRIPTION { get; set; }
        [JsonProperty(PropertyName = "ORGANIZATION")]
        public string ORGANIZATION { get; set; }
    }
}




