using System;
using System.Collections.Generic;


namespace FireStats.BL.Model
{
    class Fire
    {

        #region Свойства
        /// <summary>
        /// Адрес пожара.
        /// </summary>
        public string Adress { get; }

        /// <summary>
        /// Ранг пожара.
        /// </summary>
        public byte FireRank { get; }

        /// <summary>
        /// Время работ.
        /// </summary>
        public WorkTime WorkTime { get; }

        /// <summary>
        /// Задействованные подразделения.
        /// </summary>
        public List<User> FieldUnits { get; set; }

        /// <summary>
        /// Заявитель.
        /// </summary>
        public string Applicant { get; } //отдельный класс заявителей?

        /// <summary>
        /// Объект пожара.
        /// </summary>
        public string FireObject { get; }

        /// <summary>
        /// Владелец объекта.
        /// </summary>
        public string Owner { get; }

        /// <summary>
        /// Результат пожара.
        /// </summary>
        public string DamageResult { get; }

        /// <summary>
        /// Причина пожара.
        /// </summary>
        public string CauseOfFire { get; }

        /// <summary>
        /// Ущерб.
        /// </summary>
        public int CostOfDamage { get; }

        /// <summary>
        /// Спасено
        /// </summary>
        public int CostOfSalvage { get; }

        /// <summary>
        /// Руководитель тушения пожара (РТП).
        /// </summary>
        public string Leader { get; }

        /// <summary>
        /// Разбирался инспектор.
        /// </summary>
        public string FireInspector { get; }
        #endregion

        /// <summary>
        /// Зарегистрировать новый пожар.
        /// </summary>
        /// <param name="adress">Адрес пожара.</param>
        /// <param name="fireRank">Ранг пожара.</param>
        /// <param name="workTime">Время работы на пожаре.</param>
        /// <param name="fieldUnits">Задействованные подразделения.</param>
        /// <param name="applicant">Заявитель.</param>
        /// <param name="fireObject">Объект пожара.</param>
        /// <param name="owner">Владелец объекта.</param>
        /// <param name="damageResult">Результат пожара.</param>
        /// <param name="causeOfFire">Причина пожара.</param>
        /// <param name="costOfDamage">Ущерб.</param>
        /// <param name="costOfSalvage">Спасено.</param>
        /// <param name="leader">Руководитель тушения пожара (РТП).</param>
        /// <param name="fireInspector">Инспектор.</param>
        public Fire(string adress,
                    byte fireRank,
                    WorkTime workTime,
                    List<User> fieldUnits,
                    string applicant,
                    string fireObject,
                    string owner,
                    string damageResult,
                    string causeOfFire,
                    int costOfDamage,
                    int costOfSalvage,
                    string leader,
                    string fireInspector)
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
            if (costOfDamage < 0)
            {
                throw new ArgumentException("message", nameof(costOfDamage));
            }
            if (costOfSalvage < 0)
            {
                throw new ArgumentException("message", nameof(costOfSalvage));
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

            if (string.IsNullOrWhiteSpace(causeOfFire))
            {
                throw new ArgumentException("Причина пожара не может быть пустой или null.", nameof(causeOfFire));
            }

            if (string.IsNullOrWhiteSpace(leader))
            {
                throw new ArgumentException("РТП не может быть пустым или null.", nameof(leader));
            }

            if (string.IsNullOrWhiteSpace(fireInspector))
            {
                throw new ArgumentException("Инстпектор не может быть пустым или null.", nameof(fireInspector));
            }
            #endregion
          
            Adress = adress;
            FireRank = fireRank;
            WorkTime = workTime;
            FieldUnits = fieldUnits;
            Applicant = applicant;
            FireObject = fireObject;
            Owner = owner;
            DamageResult = damageResult;
            CauseOfFire = causeOfFire;
            CostOfDamage = costOfDamage;
            CostOfSalvage = costOfSalvage;
            Leader = leader;
            FireInspector = fireInspector;
        }

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
    }
}
