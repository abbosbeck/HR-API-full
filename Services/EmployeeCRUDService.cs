using Dadabase;
using Dadabase.Entity;
using Post2.Modules;

namespace Post2.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {

        private readonly IGenericRepositroy<Employee> _employeeRepository;
        private readonly IGenericRepositroy<Address> _addressRepository;
        private readonly IAccountNumberValidationService _accountNumberValidationService;
        public EmployeeCRUDService(IGenericRepositroy<Employee> employeeRepository, IGenericRepositroy<Address> addressRepository, IAccountNumberValidationService accountNumberValidationService)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
            _accountNumberValidationService = accountNumberValidationService;
        }
        public async Task<EmployeeModel> Create(EmployeeModel model)
        {

            var existingAddress = await _addressRepository.GetById(model.Id);
            var employee = new Employee
            {
                Name = model.Name,
                Id = model.Id,
                Deportment = model.Deportment,
                Email = model.Email,
                Salary = model.Salary
            };

            if(existingAddress != null)
                employee.Address = existingAddress;

            var creataeEmployee = await _employeeRepository.Create(employee);
            var result = new EmployeeModel
            {
                Name = creataeEmployee.Name,
                Id = creataeEmployee.Id,
                Deportment = creataeEmployee.Deportment,
                Email = creataeEmployee.Email,
                Salary = creataeEmployee.Salary,
                AddressId = creataeEmployee.Address.Id
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }

        public async Task<EmployeeModel> GetById(int id)
        {
            var model = await _employeeRepository.GetById(id);
            var result = new EmployeeModel
            {
                Name = model.Name,
                Deportment = model.Deportment,
                Id = model.Id,
                Email = model.Email,
                Salary = model.Salary
            };
            return result;
        }

        public async Task<IEnumerable<EmployeeModel>> Get()
        {
            var result = new List<EmployeeModel>();
            var employees = await _employeeRepository.GetAll();
            foreach (var employee in employees)
            {
                var model = new EmployeeModel
                {
                    Name = employee.Name,
                    Id = employee.Id,
                    Deportment = employee.Deportment,
                    Email = employee.Email,
                    Salary = employee.Salary
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                Id = model.Id,
                Name = model.Name,
                Deportment = model.Deportment,
                Email = model.Email,
                Salary = model.Salary
            };
            var updatedEmployee = await _employeeRepository.Update(id, employee);
            var result = new EmployeeModel
            {
                Id = updatedEmployee.Id,
                Name = updatedEmployee.Name,
                Deportment = updatedEmployee.Deportment,
                Email = updatedEmployee.Email,
                Salary = updatedEmployee.Salary
            };
            return result;
        }
    }
}
