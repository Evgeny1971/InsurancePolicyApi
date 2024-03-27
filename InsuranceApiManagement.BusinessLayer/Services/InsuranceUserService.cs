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
        private readonly IInsuranceUserRepository _iInsuranceUserRepository;

        public InsuranceUserService(IInsuranceUserRepository iInsuranceUserRepository)
        {
            _iInsuranceUserRepository = iInsuranceUserRepository;
        }

        public async Task<InsuranceUser> CreateInsuranceUser(InsuranceUser InsuranceUser)
        {
            return await _iInsuranceUserRepository.CreateInsuranceUser(InsuranceUser);
        }

        public async Task<bool> DeleteInsuranceUserById(long id)
        {
            return await _iInsuranceUserRepository.DeleteInsuranceUserById(id);
        }

        public List<InsuranceUser> GetAllInsuranceUsers()
        {
            return _iInsuranceUserRepository.GetAllInsuranceUsers();
        }

        public async Task<InsuranceUser> GetInsuranceUserById(long id)
        {
            return await _iInsuranceUserRepository.GetInsuranceUserById(id);
        }

        public async Task<InsuranceUser> UpdateInsuranceUser(InsuranceUserViewModel model)
        {
            return await _iInsuranceUserRepository.UpdateInsuranceUser(model);
        }
    }
}