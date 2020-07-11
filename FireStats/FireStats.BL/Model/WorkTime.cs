﻿using System;


namespace FireStats.BL.Model
{
    [Serializable]
    //TODO: Принимает автоматом заданную дату, а дольше только часы и минуты для всех оперативных моментов.
    public class WorkTime
    {
        /// <summary>
        /// Текущая/выбранная дата.
        /// </summary>
        public DateTime CurrentData { get; set; }
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

        public WorkTime(DateTime callTime)
        {
            //проверка
            CallTime = callTime;
            
        }

        //public WorkTime(DateTime callTime)
        //{
        //    CallTime = callTime;
        //}

        public WorkTime(DateTime callTime, 
                        DateTime checkOutTime, 
                        DateTime arrivalTime, 
                        DateTime barrelFeedTime, 
                        DateTime localizationTime, 
                        DateTime liquidationTime, 
                        DateTime collectionTime)
        {
            //проверка
            CallTime = callTime;
            CheckOutTime = checkOutTime;
            ArrivalTime = arrivalTime;
            BarrelFeedTime = barrelFeedTime;
            LocalizationTime = localizationTime;
            LiquidationTime = liquidationTime;
            CollectionTime = collectionTime;
        }
    }

}
