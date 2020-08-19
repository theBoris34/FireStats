using FireStats.WPF.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Services
{
    class EmployeesManagment
    {
        private readonly EmployeeRepository _Employees;
        private readonly DivisionRepository _Divisions;

        public IEnumerable<Employee> Employees => _Employees.GetAll();

        public IEnumerable<Division> Divisions => _Divisions.GetAll();

        public EmployeesManagment(EmployeeRepository Employees, DivisionRepository Divisions)
        {
            _Employees = Employees;
            _Divisions = Divisions;
        }
    }
}
