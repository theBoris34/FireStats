using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Repositories;
using System;
using System.Collections.Generic;

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

        internal void Update(Employee Employee) => _Employees.Update(Employee.Id, Employee);

        internal bool Create(Employee Employee, string DivisionName)
        {
            if (Employee is null) throw new ArgumentNullException(nameof(Employee));
            if (string.IsNullOrWhiteSpace(DivisionName)) throw new ArgumentException("Некорректное имя подразделения", nameof(DivisionName));
            var division = _Divisions.Get(DivisionName);
            if(division is null)
            {
                division = new Division { Name = DivisionName };
                _Divisions.Add(division);
            }
            division.Employees.Add(Employee);
            _Employees.Add(Employee);
            return true;
        }
    }
}
