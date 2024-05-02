using master_bppm.Models;

namespace master_bppm.Interfaces
{
    public interface IMasterBPPMServices
    {
        Task<IEnumerable<MasterDataDto>> GetMasterDataById(string nik);
        //Task<IEnumerable<MasterDataDto>> GetMasterDataByOrg(string orgName);
        Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> EditMasterData(int bppmItemId, string user, XXB7_ESS_BPPM_MASTER_DATA request);
        Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> UpdateAvailabilityData(string itemCode, string organization);
       
    }
}
