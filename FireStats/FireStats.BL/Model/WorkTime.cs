using System;

namespace FireStats.BL.Model
{
    [Serializable]
    //TODO: Принимает автоматом заданную дату, а дольше только часы и минуты для всех оперативных моментов.
    public class WorkTime
    {
        #region Свойства времени работы.
        public int Id { get; set; }
        /// <summary>
        /// Текущая/выбранная дата.
        /// </summary>
        public DateTime CurrentDate { get; set; }
        /// <summary>
        /// Время вызова.
        /// </summary>
        public DateTime CallTime { get; set; }

        /// <summary>
        /// Время убытия.
        /// </summary>
        public DateTime CheckOutTime { get; set; }

        /// <summary>
        /// Время прибытия.
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Время подачи 1-го ствола.
        /// </summary>
        public DateTime BarrelFeedTime { get; set; }

        /// <summary>
        /// Время локализации.
        /// </summary>
        public DateTime LocalizationTime { get; set; }

        /// <summary>
        /// Время ликвидации.
        /// </summary>
        public DateTime LiquidationTime { get; set; }

        /// <summary>
        /// Время сбора ПТВ и возвращения в часть.
        /// </summary>
        public DateTime CollectionTime { get; set; }
        #endregion

        //public WorkTime() { }
        public WorkTime() 
        {
            CurrentDate = DateTime.Now;
            CallTime = DateTime.Now;
            CheckOutTime = DateTime.Now;
            ArrivalTime = DateTime.Now;
            BarrelFeedTime = DateTime.Now;
            LocalizationTime = DateTime.Now;
            LiquidationTime = DateTime.Now;
            CollectionTime = DateTime.Now;
        }
        /// <summary>
        /// Установить время.
        /// </summary>
        /// <param name="callTime">Время вызова.</param>
        public WorkTime(DateTime currentDate)
        {
            //проверка
            CurrentDate = currentDate;
        }

        /// <summary>
        /// Установить время.
        /// </summary>
        /// <param name="callTime">Время вызова.</param>
        /// <param name="checkOutTime">Время выезда.</param>
        /// <param name="arrivalTime">Время прибытия.</param>
        /// <param name="barrelFeedTime">Время подачи первого ствола.</param>
        /// <param name="localizationTime">Время локализации.</param>
        /// <param name="liquidationTime">Время ликвидации.</param>
        /// <param name="collectionTime">Время полной ликвидации пожара. Отправление в часть.</param>
        public WorkTime(DateTime currentDate,
                        DateTime callTime,
                        DateTime checkOutTime,
                        DateTime arrivalTime,
                        DateTime barrelFeedTime,
                        DateTime localizationTime,
                        DateTime liquidationTime,
                        DateTime collectionTime)
        {
            //проверка
            CurrentDate = currentDate;
            CallTime = callTime;
            CheckOutTime = checkOutTime;
            ArrivalTime = arrivalTime;
            BarrelFeedTime = barrelFeedTime;
            LocalizationTime = localizationTime;
            LiquidationTime = liquidationTime;
            CollectionTime = collectionTime;
        }

        public override string ToString()
        {
            return "Временные характеристики: " + CurrentDate.ToString("dd.MM.yy") + " " + CallTime.ToString("HH:mm") + '/' + CheckOutTime.ToString("HH:mm") + '/' + ArrivalTime.ToString("HH:mm") + '/' + BarrelFeedTime.ToString("HH:mm") + '/' + LocalizationTime.ToString("HH:mm") + '/' + LiquidationTime.ToString("HH:mm") + '/' + CollectionTime.ToString("HH:mm");
            //'\t' + CallTime.ToString("dd.MM.yy HH:mm") + "\nВремя выезда подразделений: " + CheckOutTime.ToString("HH:mm") + "\nВремя прибытия: " + ArrivalTime.ToString("HH:mm") + "\nВремя подачи первого ствола: " + BarrelFeedTime.ToString("HH:mm") + "\nВремя локализации: " + LocalizationTime.ToString("HH:mm") + "\nВремя ликвидации: " + LiquidationTime.ToString("HH:mm") + "\nВремя полной ликвидации пожара, сбор ПТВ: " + CollectionTime.ToString("HH:mm");

        }


    }

}
