using InsuranceApiManagement.BusinessLayer.ViewModels;
using InsuranceApiManagement.DataLayer;
using InsuranceApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApiManagement.BusinessLayer.Services.Repository
{
    public class InsuranceUserRepository : IInsuranceUserRepository
    {
        private readonly InsuranceDbContext _dbContext;
        public InsuranceUserRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InsuranceUser> CreateInsuranceUser(InsuranceUser _insuranceUser)
        {
            try
            {
                var result = await _dbContext.InsuranceUsers.AddAsync(_insuranceUser);
                await _dbContext.SaveChangesAsync();
                return _insuranceUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteInsuranceUserById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.InsuranceUsers.Single(a => a.ID == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<InsuranceUser> GetAllInsuranceUsers()
        {
            try
            {
                var result = _dbContext.InsuranceUsers.
                OrderByDescending(x => x.ID).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<InsuranceUser> GetInsuranceUserById(long id)
        {
            try
            {
                return await _dbContext.InsuranceUsers.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<InsuranceUser> UpdateInsuranceUser(InsuranceUserViewModel model)
        {
            var insuranceUser = await _dbContext.InsuranceUsers.FindAsync(model.ID);
            try
            {
                insuranceUser.Name = model.Name;
                insuranceUser.Email = model.Email;
                insuranceUser.ID = model.ID;

                _dbContext.InsuranceUsers.Update(insuranceUser);
                await _dbContext.SaveChangesAsync();
                return insuranceUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}