using master_bppm.Models;

namespace master_bppm.Interfaces
{
    public interface IMasterBPPM
    {
        Task<IEnumerable<MasterDataDto>> GetMasterDataByIdRepo(string nik);
        //Task<IEnumerable<MasterDataDto>> GetMasterDataByOrgRepo(string orgName);
        Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> EditMasterDataRepo(int bbpmitemid,string user, XXB7_ESS_BPPM_MASTER_DATA request);
        Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> UpdateAvailabilityDataRepo(string itemCode, string organization);
        
    }
}
