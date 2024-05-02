using master_bppm.Interfaces;
using master_bppm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace master_bppm.Services
{
    public class MasterBPPMServices : IMasterBPPMServices
    {
        private readonly IMasterBPPM _repository;

        public MasterBPPMServices(IMasterBPPM repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MasterDataDto>> GetMasterDataById(string nik)
        {
           
            return await _repository.GetMasterDataByIdRepo(nik);
        }

        //public async Task<IEnumerable<MasterDataDto>> GetMasterDataByOrg(string orgName)
        //{

        //    return await _repository.GetMasterDataByOrgRepo(orgName);
        //}

       
       public async Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> EditMasterData(int bppmItemId, string user,XXB7_ESS_BPPM_MASTER_DATA request)
        {

            return await _repository.EditMasterDataRepo(bppmItemId, user, request);
        }

        public async Task<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>> UpdateAvailabilityData(string itemCode, string organization)
        {

            return await _repository.UpdateAvailabilityDataRepo(itemCode,organization);
        }

    }
}
