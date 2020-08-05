using System;
using System.Collections.Generic;


namespace FireStats.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пожар.
    /// </summary>
    public class Fire
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public Fire() { }
        #region Свойства


        /// <summary>
        /// Адрес пожара.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Ранг пожара.
        /// </summary>
        public byte FireRank { get; set; }

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
        /// Объект пожара.
        /// </summary>
        public string FireObject { get; set; }

        /// <summary>
        /// Владелец объекта.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Результат пожара.
        /// </summary>
        public string DamageResult { get; set; }

        /// <summary>
        /// Причина пожара.
        /// </summary>
        public string CauseOfFire { get; set; }

        /// <summary>
        /// Ущерб.
        /// </summary>
        public int CostOfDamage { get; set; }

        /// <summary>
        /// Спасено
        /// </summary>
        public int CostOfSalvage { get; set; }

        /// <summary>
        /// Руководитель тушения пожара (РТП).
        /// </summary>
        public string Leader { get; set; }

        /// <summary>
        /// Разбирался инспектор.
        /// </summary>
        public string FireInspector { get; set; }

        /// <summary>
        /// Пользователь внесший пожар/изменения.
        /// </summary>
        public string UserName { get; set; }
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
                    string fireInspector,
                    string userName)
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
                throw new ArgumentException("Инспектор не может быть пустым или null.", nameof(fireInspector));
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым или null", nameof(userName));
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
            UserName = userName;
        }

        /// <summary>
        /// Вывод пожара в виде отчета.
        /// </summary>
        /// <returns>Описание пожара.</returns>
        public override string ToString()
        {
            return "------------" + $"\n{WorkTime.CurrentDate.ToString("dd.MM.yy")}  {Adress}. " +
                    $"РАНГ ПОЖАРА: \"{FireRank}\". "
                    + $"\nВ {WorkTime.CallTime:HH:mm} в ЦУКС по Какой-то области от заявителя ({Applicant}) \nпоступило сообщение о пожаре {FireObject}. \nВладелец объекта: {Owner}. "
                    + $"\nВ результате пожара - {DamageResult}. "
                    + $"\nПричина пожара - {CauseOfFire}. "
                    + $"\nУщерб на сумму {CostOfDamage} руб. "
                    + $"\nСпасено имущество на сумму {CostOfSalvage} руб. "
                    + $"\nВыезжали: {FieldUnits}. "
                    + $"\nВремя: выезд {WorkTime.CheckOutTime:HH:mm}/ прибыте {WorkTime.ArrivalTime:HH:mm}/ подача ствола {WorkTime.BarrelFeedTime:HH:mm}/ локализации {WorkTime.LocalizationTime:HH:mm}/ ликвидации {WorkTime.LiquidationTime:HH:mm}/ сбор ПТВ {WorkTime.CollectionTime:HH:mm}. "
                    + $"\nРТП: {Leader}. "
                    + $"\nРазбирался: {FireInspector}."
                    + $"\nДанные внес: {UserName}";
        }
    }
}
