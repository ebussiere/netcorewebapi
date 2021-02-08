using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcorewebapi.Data.Models;
using netcorewebapi.Data.ViewModels;

namespace netcorewebapi.Data.Services
{
    public class EmployeesService
    {
        private AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x=>x.Id==id);
            return employee;
        }

        public void AddEmployee(EmployeeVM employee)
        {
            var _employee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
            _context.Employees.Add(_employee);
            _context.SaveChanges();
        }

        public Employee UpdateEmployeeById(int employeeId, EmployeeVM employee)
        {
            var _employee = _context.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (_employee!=null)
            {
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
            }
            _context.SaveChanges();
            return _employee;
        }

        public void DeleteEmployeeById(int employeeId)
        {
            var _employee = _context.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (_employee!=null)
            {
                _context.Employees.Remove(_employee);
            }
            _context.SaveChanges();
        }
    }
}
