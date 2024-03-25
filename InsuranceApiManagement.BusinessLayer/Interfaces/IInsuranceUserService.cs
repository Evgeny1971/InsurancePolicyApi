using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApiManagement.BusinessLayer.Interfaces
{
    public interface IInsuranceUserService
    {
        List<InsuranceUser> GetAllInsuranceUsers();
        Task<InsuranceUser> CreateInsuranceUser(InsuranceUser insuranceUser);
        Task<InsuranceUser> GetInsuranceUserById(long id);
        Task<bool> DeleteInsuranceUserById(long id);
        Task<InsuranceUser> UpdateInsuranceUser(InsuranceUserViewModel model);
    }
}
