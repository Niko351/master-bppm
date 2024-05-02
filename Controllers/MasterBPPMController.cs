using master_bppm.Interfaces;
using master_bppm.Models;
using master_bppm.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourMicroservice.Controllers
{
    [EnableCors("allowall")]
    [Route("api/")]
    [ApiController]
    public class MasterBPPMController : ControllerBase
    {
        private readonly IMasterBPPMServices _masterBPPMService;
        private readonly ILogger<MasterBPPMController> _logger;

        public MasterBPPMController(IMasterBPPMServices masterBPPMService, ILogger<MasterBPPMController> logger)
        {
            _masterBPPMService = masterBPPMService;
            _logger = logger;
        }

        [HttpGet("GetMasterBPPM")]
        public async Task<ActionResult<IEnumerable<MasterDataDto>>> GetMasterBPPM(string nik)
        {
            var data = await _masterBPPMService.GetMasterDataById(nik);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost("EditMasterBPPM")]
        public async Task<ActionResult<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>>> EditMasterBPPM(int bppmItemId, string user,XXB7_ESS_BPPM_MASTER_DATA request)
        {
            //var data = await _masterBPPMService.EditMasterData(bppmItemId, user,request);

            //if (data == null)
            //{
            //    return NotFound();
            //}

            //return Ok(data);

            try
            {
                var data = await _masterBPPMService.EditMasterData(bppmItemId, user, request);

                if (data == null)
                {
                    return NotFound(); 
                }
                else
                {
                    return Ok(data); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Repository");

                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message); 
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

        }

        //Update
        [HttpPost("UpdateAvailabilityBPPM")]
        public async Task<ActionResult<IEnumerable<XXB7_ESS_BPPM_MASTER_DATA>>> UpdateAvailabilityBPPM(string itemCode, string organization)
        {

            try
            {
                var data = await _masterBPPMService.UpdateAvailabilityData(itemCode,organization);

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Repository");

                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, "Internal server error");
                }
            }

        }


    }
}