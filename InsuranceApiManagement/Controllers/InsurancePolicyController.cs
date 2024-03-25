using InsuranceApiManagement.BusinessLayer.Interfaces;
using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApiManagement.Controllers
{
    [ApiController]
    public class InsurancePolicyController : ControllerBase //, IInsurancePolicyService
    {
        private readonly IInsurancePolicyService _iInsurancePolicyService;
        public InsurancePolicyController(IInsurancePolicyService insurancePolicyService)
        {
            _iInsurancePolicyService = insurancePolicyService;
        }

        [HttpPost]
        [Route("create-policy")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInsurancePolicy([FromBody] InsurancePolicy model)
        {
            var policyExists = await _iInsurancePolicyService.GetInsurancePolicyById(model.ID);
            if (policyExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy already exists!" });
            var result = await _iInsurancePolicyService.CreateInsurancePolicy(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Insurance Policy created successfully!" });

        }


        [HttpPut]
        [Route("update-policy")]
        public async Task<IActionResult> UpdateInsurancePolicy([FromBody] InsurancePolicyViewModel model)
        {
            var policy = await _iInsurancePolicyService.UpdateInsurancePolicy(model);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {model.ID} cannot be found" });
            }
            else
            {
                var result = await _iInsurancePolicyService.UpdateInsurancePolicy(model);
                return Ok(new Response { Status = "Success", Message = "Insurance Policy updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-policy")]
        public async Task<IActionResult> DeleteInsurancePolicy(long id)
        {
            var policy = await _iInsurancePolicyService.GetInsurancePolicyById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _iInsurancePolicyService.DeleteInsurancePolicyById(id);
                return Ok(new Response { Status = "Success", Message = "Insurance policy deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-policy-by-id")]
        public async Task<IActionResult> GetInsurancePolicyById(long id)
        {
            var policy = await _iInsurancePolicyService.GetInsurancePolicyById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(policy);
            }
        }

        [HttpGet]
        [Route("get-all-policies")]
        public async Task<IEnumerable<InsurancePolicy>> GetAllPolicies()
        {
            return _iInsurancePolicyService.GetAllInsurancePolicies();
        }
    }
}