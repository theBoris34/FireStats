using FireStats.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.BL.Controller
{
    class FireController : ControllerBase
    {
        private const string FIRES_FILE_NAME = "fires.dat";
        private readonly UserController user;
        public List<Fire> Fires { get; }

        public FireController(UserController user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Fires = GetAllFiers();
        }

        private List<Fire> GetAllFiers()
        {
            return Load<List<Fire>>(FIRES_FILE_NAME) ?? new List<Fire>();
        }

        private void Save()
        {
            base.Save(FIRES_FILE_NAME, Fires);
        }

    }
}
