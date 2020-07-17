using System;
using System.Collections.Generic;

namespace FireStats.BL.Model
{
    [Serializable]
    /// <summary>
    /// Рабочая смена(сутки).
    /// </summary>
    public class WorkShift
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public WorkShift()
        {

        }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }
       
        /// <summary>
        /// Дата суток.
        /// </summary>
        public DateTime CurrentData { get; set; } // Console.WriteLine(dateOnly.ToString("d")) == 6/1/2008 

        /// <summary>
        /// Список пожаров за сутки.
        /// </summary>
        public List<Fire> Fires { get; set; }
       
        /// <summary>
        /// Список чрезвычаайных ситуаций за сутки.
        /// </summary>
        public List<Emergency> Emergencies { get; set; }

       
        public WorkShift(User user, DateTime date)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
            CurrentData = date;
            Fires = new List<Fire>();
            Emergencies = new List<Emergency>();
        }

        
        




    }
}
