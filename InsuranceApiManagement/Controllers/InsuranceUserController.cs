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
    public class InsuranceUserController : ControllerBase //, IInsuranceUserService
    {
        private readonly IInsuranceUserService _iInsuranceUserService;
        public InsuranceUserController(IInsuranceUserService iInsuranceUserService)
        {
            _iInsuranceUserService = iInsuranceUserService;
        }

        [HttpPost]
        [Route("create-user")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInsuranceUser([FromBody] InsuranceUser model)
        {
            var userExists = await _iInsuranceUserService.GetInsuranceUserById(model.ID);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance user already exists!" });
            var result = await _iInsuranceUserService.CreateInsuranceUser(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance user creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Insurance user created successfully!" });

        }


        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> UpdateInsuranceUser([FromBody] InsuranceUserViewModel model)
        {
            var user = await _iInsuranceUserService.UpdateInsuranceUser(model);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance user With Id = {model.ID} cannot be found" });
            }
            else
            {
                var result = await _iInsuranceUserService.UpdateInsuranceUser(model);
                return Ok(new Response { Status = "Success", Message = "Insurance user updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-user")]
        public async Task<IActionResult> DeleteInsuranceUser(long id)
        {
            var user = await _iInsuranceUserService.GetInsuranceUserById(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance user With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _iInsuranceUserService.DeleteInsuranceUserById(id);
                return Ok(new Response { Status = "Success", Message = "Insurance user deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-user-by-id")]
        public async Task<IActionResult> GetInsuranceUserById(long id)
        {
            var user = await _iInsuranceUserService.GetInsuranceUserById(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance user With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet]
        [Route("get-all-policies")]
        public async Task<IEnumerable<InsuranceUser>> GetAllUsers()
        {
            return _iInsuranceUserService.GetAllInsuranceUsers();
        }

        
    }
}