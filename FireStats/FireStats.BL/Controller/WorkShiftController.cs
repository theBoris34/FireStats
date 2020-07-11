using FireStats.BL.Model;
using System;
using System.Collections.Generic;

namespace FireStats.BL.Controller
{
    public class WorkShiftController : ControllerBase
    {
        /// <summary>
        ///  Имя файла с данными о пожарах.
        /// </summary>
        private const string WORKSHIFT_FILE_NAME = "workshift.dat";
        /// <summary>
        ///  Имя файла с данными о ЧС.
        /// </summary>
        private const string EMERGANCY_FILE_NAME = "emergency.dat";
        /// <summary>
        ///  Имя файла с данными о пожарах.
        /// </summary>
        private const string FIRES_FILE_NAME = "fires.dat";
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;
       
        /// <summary>
        /// Рабочая смена (сутки).
        /// </summary>
        public WorkShift WorkShift { get; }
        /// <summary>
        /// Список пожаров за сутки.
        /// </summary>
        public List<Fire> Fires { get; }


        /// <summary>
        /// Список чрезвычаайных ситуаций за сутки.
        /// </summary> 
        public List<Emergency> Emergencies { get; }

        public WorkShiftController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Fires = GetAllFires();
            Emergencies = GetAllEmergencies();
            WorkShift = GetWorkShift();

        }

        /// <summary>
        /// Добавить пожар в список.
        /// </summary>
        /// <param name="fire">Пожар</param>
        public void Add(Fire fire)
        {
            if (Fires.Find(f => string.Equals(f.Adress, fire.Adress, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                Fires.Add(fire);
                Save();
            }
            else
            {
                throw new ArgumentException("Пожар по этому адресу уже зарегистрирован!", nameof(fire));
            }
        }

        /// <summary>
        /// Добавить ЧС в список.
        /// </summary>
        /// <param name="emergency">ЧС.</param>
        public void Add(Emergency emergency)
        {
            if (Emergencies.Find(e => string.Equals(e.Adress, emergency.Adress, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                Emergencies.Add(emergency);
                Save();
            }
            else
            {
                throw new ArgumentException("ЧС по этому адресу ужке зарегистрирована!", nameof(emergency));
            }
        }

        private WorkShift GetWorkShift()
        {
            return Load<WorkShift>(WORKSHIFT_FILE_NAME) ?? new WorkShift(user, DateTime.Now);
        }

        /// <summary>
        /// Загрузить все ЧС из файла.
        /// </summary>
        /// <returns>Список ЧС.</returns>
        private List<Emergency> GetAllEmergencies()
        {
            return Load<List<Emergency>>(EMERGANCY_FILE_NAME) ?? new List<Emergency>();
        }

        /// <summary>
        /// Загрузить все пожары из файла.
        /// </summary>
        /// <returns>Список пожаров.</returns>
        private List<Fire> GetAllFires()
        {
            return Load<List<Fire>>(FIRES_FILE_NAME) ?? new List<Fire>();           
        }

        private void Save()
        {
            Save(FIRES_FILE_NAME, Fires);
            Save(EMERGANCY_FILE_NAME, Emergencies);
            Save(WORKSHIFT_FILE_NAME, WorkShift);
        }
 
    }
}
