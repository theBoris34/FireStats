using FireStats.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireStats.BL.Controller
{
    public class WorkShiftController : ControllerBase
    {
        bool IsNewWorkShift = false;
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Рабочая смена (сутки).
        /// </summary>
        public WorkShift WorkShift { get; set; }

        /// <summary>
        /// Список суток.
        /// </summary>
        public List<WorkShift> WorkShifts { get; set; }

        public WorkShift CurrentWorkShift { get; set; }
        /// <summary>
        /// Список чрезвычаайных ситуаций за сутки.
        /// </summary> 
        public List<Emergency> Emergencies { get; }

        public WorkShiftController(DateTime date)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            WorkShifts = GetWorkShift();

            //CurrentWorkShift = WorkShifts.SingleOrDefault(w => w == date);
            if (CurrentWorkShift == null)
            {
                CurrentWorkShift = new WorkShift();
                WorkShifts.Add(CurrentWorkShift);
                IsNewWorkShift = true;
                Save();
            }
            CurrentWorkShift.Fires = GetAllFires();
            CurrentWorkShift.Emergencies = GetAllEmergencies();
        }

        /// <summary>
        /// Добавить пожар в список.
        /// </summary>
        /// <param name="fire">Пожар</param>
        public void Add(Fire fire)
        {
            if (WorkShift.Fires.Find(f => string.Equals(f.Adress, fire.Adress, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                WorkShift.Fires.Add(fire);                
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
            if (WorkShift.Emergencies.Find(e => string.Equals(e.Adress, emergency.Adress, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                WorkShift.Emergencies.Add(emergency);
                Save();
            }
            else
            {
                throw new ArgumentException("ЧС по этому адресу ужке зарегистрирована!", nameof(emergency));
            }
        }

        private List<WorkShift> GetWorkShift()
        {
            return Load<WorkShift>() ?? new List<WorkShift>();
        }

        /// <summary>
        /// Загрузить все ЧС из файла.
        /// </summary>
        /// <returns>Список ЧС.</returns>
        private List<Emergency> GetAllEmergencies()
        {
            return Load<Emergency>() ?? new List<Emergency>();
        }

        /// <summary>
        /// Загрузить все пожары из файла.
        /// </summary>
        /// <returns>Список пожаров.</returns>
        private List<Fire> GetAllFires()
        {
            return Load<Fire>() ?? new List<Fire>();           
        }

        private void Save()
        {
            Save();
        }
 
    }
}
