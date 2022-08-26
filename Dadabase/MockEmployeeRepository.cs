using Dadabase.Entity;
using System.Collections.Concurrent;

namespace Dadabase
{

    public class MockEmployeeRepository    
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private static object locker = new();

        public MockEmployeeRepository()
        {
            Init();
        }
        private void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, Name = "Abbos Abduqayumov", Deportment = "IT", Email = "Abbosdev@gmail.com" });
            _employees.TryAdd(2, new Employee { Id = 2, Name = "John Due", Deportment = "Management", Email = "John@gmail.com" });
            _employees.TryAdd(3, new Employee { Id = 3, Name = "Daniel Elbes", Deportment = "Management", Email = "Daniel@gmail.com" });
            _employees.TryAdd(4, new Employee { Id = 4, Name = "Kedri Pau", Deportment = "IT", Email = "KPA@gmail.com" });
            _employees.TryAdd(5, new Employee { Id = 5, Name = "Lii En Sia", Deportment = "Management", Email = "liii@gmail.com" });
        }

        public async Task<IEnumerable<Employee>> Employees()
        {
            return await Task.FromResult(_employees.Values);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            int newId = 0;
            lock (locker)
            {
                newId = _employees.Keys.Max() + 1;
            }
            employee.Id = newId;
            _employees.TryAdd(newId, employee);
            employee.Id = newId;
            return await Task.FromResult(employee);
        }

        public async Task<Employee> Employee(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            _employees[employee.Id] = employee;
            return await Task.FromResult(employee);

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            if (_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
    }
}
