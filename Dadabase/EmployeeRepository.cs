using Dadabase;
using Dadabase.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dadabase
{
    public class EmployeeRepository : IGenericRepositroy<Employee>
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> Create(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> GetById(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var updatedEmployee = _dbContext.Employees.Attach(employee);
            updatedEmployee.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
