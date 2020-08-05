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


        public Emergency() { }

        #region Свойства
        /// <summary>
        /// ID для базы данных.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ID пользователя для базы данных.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Адрес происшествия.
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
        /// Описание происшествия.
        /// </summary>
        public string Description { get; set; }

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
        public string EmergencyObject { get; set; }

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
        /// <param name="description">Описание происшествия.</param>
        /// <param name="workTime">Время работ.</param>
        /// <param name="fieldUnits">Задействованные подразделения.</param>
        /// <param name="applicant">Заявитель.</param>
        /// <param name="emergencyObject">Объект ЧС.</param>
        /// <param name="owner">Владелец объекта.</param>
        /// <param name="damageResult">Результат происшествия.</param>
        /// <param name="leader">Руководитель ликвидацией ЧС.</param>
        /// <param name="injured">Пострадавшие.</param>
        public Emergency(string adress,
                    string description,
                    WorkTime workTime,
                    List<User> fieldUnits,
                    string applicant,
                    string emergencyObject,
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

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Описание не может быть пустым или null. ", nameof(description));
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

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("Владелец объекта не может быть пустым или null.", nameof(owner));
            }

            if (string.IsNullOrWhiteSpace(damageResult))
            {
                throw new ArgumentException("Результат происшествия не может быть пустым или null.", nameof(damageResult));
            }

            if (string.IsNullOrWhiteSpace(leader))
            {
                throw new ArgumentException("Руководитель ликвидацией ЧС не может быть пустым или null.", nameof(leader));
            }
            #endregion

            Adress = adress;
            WorkTime = workTime;
            Description = description;
            FieldUnits = fieldUnits;
            Applicant = applicant;
            EmergencyObject = emergencyObject;
            Owner = owner;
            DamageResult = damageResult;
            Leader = leader;
            Injured = injured;
        }


        public override string ToString()
        {
            return "============" + $"\n{WorkTime.CurrentDate.ToString("dd.MM.yy")}  {Adress}. "
                     + $"\nВ {WorkTime.CallTime:HH:mm} в ЦУКС по Какой-то области от заявителя ({Applicant}) \nпоступило сообщение о происшествии: {Description}. \nВладелец объекта: {Owner}. "
                     + $"\nВ результате пожара - {DamageResult}. "
                     + $"\nВыезжали: {FieldUnits}. "
                     + $"\nВремя: выезд {WorkTime.CheckOutTime:HH:mm}/ прибыте {WorkTime.ArrivalTime:HH:mm}/ подача ствола {WorkTime.BarrelFeedTime:HH:mm}/ локализации {WorkTime.LocalizationTime:HH:mm}/ ликвидации {WorkTime.LiquidationTime:HH:mm}/ сбор ПТВ {WorkTime.CollectionTime:HH:mm}. "
                     + $"\nРТП: {Leader}. ";
        }
    }
}
