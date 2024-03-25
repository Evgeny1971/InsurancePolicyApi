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
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IInsurancePolicyService _iInsurancePolicyRepository;

        public InsurancePolicyService(IInsurancePolicyService InsurancePolicyRepository)
        {
            _iInsurancePolicyRepository = InsurancePolicyRepository;
        }

        public async Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            return await _iInsurancePolicyRepository.CreateInsurancePolicy(insurancePolicy);
        }

        public async Task<bool> DeleteInsurancePolicyById(long id)
        {
            return await _iInsurancePolicyRepository.DeleteInsurancePolicyById(id);
        }

        public List<InsurancePolicy> GetAllInsurancePolicies()
        {
            return _iInsurancePolicyRepository.GetAllInsurancePolicies();
        }

        public async Task<InsurancePolicy> GetInsurancePolicyById(long id)
        {
            return await _iInsurancePolicyRepository.GetInsurancePolicyById(id);
        }

        public async Task<InsurancePolicy> UpdateInsurancePolicy(InsurancePolicyViewModel model)
        {
            return await _iInsurancePolicyRepository.UpdateInsurancePolicy(model);
        }
    }
}