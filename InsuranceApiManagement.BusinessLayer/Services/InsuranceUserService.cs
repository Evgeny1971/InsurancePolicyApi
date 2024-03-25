using InsuranceApiManagement.BusinessLayer.Interfaces;
using InsuranceApiManagement.BusinessLayer.Services.Repository;
using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApiManagement.BusinessLayer.Services
{
    public class InsuranceUserService : IInsuranceUserService
    {
        private readonly IInsuranceUserRepository _iInsuranceUserService;

        public InsuranceUserService(IInsuranceUserRepository InsuranceApiRepository)
        {
            _iInsuranceUserService = InsuranceApiRepository;
        }

        public async Task<InsuranceUser> CreateInsuranceUser(InsuranceUser InsuranceUser)
        {
            return await _iInsuranceUserService.CreateInsuranceUser(InsuranceUser);
        }

        public async Task<bool> DeleteInsuranceUserById(long id)
        {
            return await _iInsuranceUserService.DeleteInsuranceUserById(id);
        }

        public List<InsuranceUser> GetAllInsuranceUsers()
        {
            return _iInsuranceUserService.GetAllInsuranceUsers();
        }

        public async Task<InsuranceUser> GetInsuranceUserById(long id)
        {
            return await _iInsuranceUserService.GetInsuranceUserById(id);
        }

        public async Task<InsuranceUser> UpdateInsuranceUser(InsuranceUserViewModel model)
        {
            return await _iInsuranceUserService.UpdateInsuranceUser(model);
        }
    }
}