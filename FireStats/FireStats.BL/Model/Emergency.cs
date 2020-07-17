using System;
using System.Collections.Generic;


namespace FireStats.BL.Model
{
    [Serializable]
    /// <summary>
    /// Чрезвычайная ситуация.
    /// </summary>
    public class Emergency
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkShiftId { get; set; }

        public Emergency()
        {
        }

        #region Свойства
        /// <summary>
        /// Адрес пожара.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Критерий ЧС.
        /// </summary>
        public bool СriterionEmergency { get; set; }

        /// <summary>
        /// Время работ.
        /// </summary>
        public WorkTime WorkTime { get; set; }

        /// <summary>
        /// Задействованные подразделения.
        /// </summary>
        public List<User> FieldUnits { get; set; }

        /// <summary>
        /// Заявитель.
        /// </summary>
        public string Applicant { get; set; } //отдельный класс заявителей?

        /// <summary>
        /// Объект ЧС.
        /// </summary>
        public string FireObject { get; set; }

        /// <summary>
        /// Владелец объекта.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Результат ЧС.
        /// </summary>
        public string DamageResult { get; set; }

        /// <summary>
        /// Руководитель ликвидации ЧС.
        /// </summary>
        public string Leader { get; set; }

        /// <summary>
        /// Пострадавшие.
        /// </summary>
        public List<String> Injured { get; set; }
        #endregion

        /// <summary>
        /// Зарегистрировать чрезвычайную ситуацию.
        /// </summary>
        /// <param name="adress">Адрес ЧС.</param>
        /// <param name="workTime">Время работ.</param>
        /// <param name="fieldUnits">Задействованные подразделения.</param>
        /// <param name="applicant">Заявитель.</param>
        /// <param name="fireObject">Объект ЧС.</param>
        /// <param name="owner">Владелец объекта.</param>
        /// <param name="damageResult">Результат ЧС.</param>
        /// <param name="leader">Руководитель ликвидацией ЧС.</param>
        /// <param name="injured">Пострадавшие.</param>
        public Emergency(string adress,
                    WorkTime workTime,
                    List<User> fieldUnits,
                    string applicant,
                    string fireObject,
                    string owner,
                    string damageResult,
                    string leader,
                    List<String> injured)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new ArgumentException("Адрес не может быть пустым или null.", nameof(adress));
            }
            if (workTime == null)
            {
                throw new ArgumentException("Время не может быть пустым или null.", nameof(workTime));
            }
            if (fieldUnits == null)
            {
                throw new ArgumentException("Подразделения не могут быть пустыми или null.", nameof(fieldUnits));
            }
            if (injured == null)
            {
                throw new ArgumentNullException("Пострадавшие не могут быть null.", nameof(injured));
            }
            if (string.IsNullOrWhiteSpace(applicant))
            {
                throw new ArgumentException("Заявитель не может быть пустым или null.", nameof(applicant));
            }

            if (string.IsNullOrWhiteSpace(fireObject))
            {
                throw new ArgumentException("Объект пожара не может быть пустым или null.", nameof(fireObject));
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("Владелец объекта не может быть пустым или null.", nameof(owner));
            }

            if (string.IsNullOrWhiteSpace(damageResult))
            {
                throw new ArgumentException("Результат пожара не может быть пустым или null.", nameof(damageResult));
            }          

            if (string.IsNullOrWhiteSpace(leader))
            {
                throw new ArgumentException("РТП не может быть пустым или null.", nameof(leader));
            }            
            #endregion
          
            Adress = adress;
            WorkTime = workTime;
            FieldUnits = fieldUnits;
            Applicant = applicant;
            FireObject = fireObject;
            Owner = owner;
            DamageResult = damageResult;
            Leader = leader;
            Injured = injured ;
        }

        /*
        public override string ToString()
        {
            return Adress + ". " + 
                    $"Ранг пожара \"{FireRank}\". "     
                    + $"В {WorkTime.CallTime} в ЦУКС по Какой-то области от заявителя ({Applicant}) поступило сообщение о пожаре {FireObject}, владелец: {Owner}. "  
                    + $"В результате пожара: {DamageResult}. " 
                    + $"Причина пожара - {CauseOfFire}. "
                    + $"Ущерб - {CostOfDamage}. "
                    + $"Спасено имущество на сумму {CostOfSalvage}. "
                    + $"Выезжали: {FieldUnits}. "
                    + $"Время: {WorkTime.CheckOutTime}/{WorkTime.ArrivalTime}/{WorkTime.BarrelFeedTime}/{WorkTime.LocalizationTime}/{WorkTime.LiquidationTime}/{WorkTime.CollectionTime}. "
                    + $"РТП: {Leader}"
                    + $"Разбирался: {FireInspector}"; 
        }
        */
    }
}
