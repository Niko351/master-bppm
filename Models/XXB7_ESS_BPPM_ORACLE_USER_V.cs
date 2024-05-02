using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace master_bppm.Models
{
    [Keyless]
    public class XXB7_ESS_BPPM_ORACLE_USER_V
    {
        [JsonProperty(PropertyName = "USER_ID")]
        public int USER_ID { get; set; }
        [JsonProperty(PropertyName = "FULL_NAME")]
        public string? FULL_NAME { get; set; }
        [JsonProperty(PropertyName = "EMPLOYEE_NUMBER")]
        public string? EMPLOYEE_NUMBER { get; set; }
        [JsonProperty(PropertyName = "RESPONSIBILITY_NAME")]
        public string RESPONSIBILITY_NAME { get; set; }
        [JsonProperty(PropertyName = "ORGANIZATION_CODE")]
        public string ORGANIZATION_CODE { get; set; }


    }
}
