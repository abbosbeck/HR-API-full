using Dadabase.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dadabase
{
    public class AddressRepository : IGenericRepositroy<Address>
    {
        private readonly AppDbContext _dbContext;

        public AddressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Address> Create(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<bool> Delete(int id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);
            if (address != null)
            {
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Address> GetById(int id)
        {
            return await _dbContext.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async Task<Address> Update(int id, Address address)
        {
            var updatedEmployee = _dbContext.Addresses.Attach(address);
            updatedEmployee.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return address;
        }
    }
}
