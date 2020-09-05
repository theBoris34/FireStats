using FireStats.WPF.Models.Applicants;
using FireStats.WPF.Services.Repositories;
using System;
using System.Collections.Generic;

namespace FireStats.WPF.Services
{
    class FireManagment
    {
        private readonly FireRepository _Fires;

        public IEnumerable<Fire> Fires => _Fires.GetAll();

        public FireManagment(FireRepository Fires)
        {
            _Fires = Fires;
        }

        internal void Update(Fire Fire) => _Fires.Update(Fire.Id, Fire);

        internal bool Create(Fire Fire)
        {
            if (Fire is null) throw new ArgumentNullException(nameof(Fire));
            _Fires.Add(Fire);

            return true;
        }
    }
}
