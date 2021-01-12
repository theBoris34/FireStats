using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FireStats.WPF.Services
{
    class EmployeesManagment
    {

        private readonly DivisionRepository _Divisions;
        private readonly EmployeeRepository _Employees;


        public IEnumerable<Division> Divisions => _Divisions.GetAll();
        public IEnumerable<Employee> Employees => _Employees.GetAll();


        public EmployeesManagment(DivisionRepository divisions, EmployeeRepository employees)
        {
            _Divisions = divisions;
            _Employees = employees;
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
