﻿using FireStats.WPF.Models.Departments;
using FireStats.WPF.Services.Base;
using System.Linq;

namespace FireStats.WPF.Services
{
    class DivisionRepository : RepositoryInMemory<Division>
    {
        public DivisionRepository(): base(TestData.Divisions) { }

        public Division Get(string DivisionName) => GetAll().FirstOrDefault(d => d.Name == DivisionName);

        protected override void Update(Division Source, Division Destination)
        {
            Destination.Name = Source.Name;           
            Destination.Note = Source.Note;
        }
    }
}
