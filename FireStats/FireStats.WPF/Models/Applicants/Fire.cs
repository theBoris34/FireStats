using FireStats.WPF.Models.Base;
using FireStats.WPF.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Models.Applicants
{
    /// <summary> Пожар. </summary>
    class Fire : Accident
    {
        #region Свойства
        /// <summary> Ранг пожара.</summary>
        public string FireRank { get; set; }

        /// <summary>  внесший пожар/изменения. </summary>
        public int UserId { get; set; }

        /// <summary> Время подачи первого ствола. </summary>
        public DateTime WaterFeedTime { get; set; }

        /// <summary> Время локализации. </summary>
        public DateTime LocalizationTime { get; set; }

        /// <summary> Время ликвидации. </summary>
        public DateTime LiquidationTime { get; set; }

        /// <summary> Время полной ликвидации пожара. Сбор ПТВ. Возвращение в часть. </summary>
        public DateTime EndOfWorkTime { get; set; }

        /// <summary> Задействованные отделения. </summary>
        //public List<User> FieldUnits { get; set; }

        /// <summary> Заявитель. </summary>
        public Applicant Applicant { get; set; }

        /// <summary> Объект пожара. </summary>
        //public string FireObject { get; set; }

        /// <summary> Владелец объекта. </summary>
        public string Owner { get; set; }

        /// <summary> Причина пожара. </summary>
        public string CauseOfFire { get; set; }

        /// <summary> Ущерб. </summary>
        public ulong CostOfDamage { get; set; }

        /// <summary> Уничтоженно огнем. </summary>
        public string LostInFire { get; set; }

        /// <summary> Спасено. </summary>
        public ulong CostOfSalvage { get; set; }

        /// <summary> Спасено от огня. </summary>
        public string Saved { get; set; }

        //TODO: Звенья ГДЗС.
        //TODO: Современные средства пожаротушения.
        //TODO: Службы жизнеобеспечания

        /// <summary> Руководитель тушения пожара (РТП). </summary>
        public ICollection<Employee> FightingLeader { get; set; }

        /// <summary> Разбирались. </summary>
        public ICollection<Employee> FireInspector { get; set; } 
        #endregion

        /// <summary>
        /// Пожар.
        /// </summary>
        /// <param name="adress">Адрес пожара.</param>
        /// <param name="fireRank">Ранг пожара.</param>
        /// <param name="date">Дата пожара.</param>
        /// <param name="timeOfCall">Время вызова.</param>
        public Fire(string adress, 
                    string fireRank,
                    DateTime date,
                    DateTime timeOfCall)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new ArgumentException($"'{nameof(adress)}' не может быть пустым или содержать только пробел", nameof(adress));
            }

            if (string.IsNullOrWhiteSpace(fireRank))
            {
                throw new ArgumentException($"'{nameof(fireRank)}' не может быть пустым или содержать только пробел", nameof(fireRank));
            } 
            #endregion

            Date = date;
            Adress = adress;
            FireRank = fireRank;
            TimeOfCall = timeOfCall;
        }


        /// <summary>
        /// Пожар.
        /// </summary>
        /// <param name="adress">Адрес пожара.</param>
        /// <param name="fireRank">Ранг пожара.</param>
        /// <param name="date">Дата пожара.</param>
        /// <param name="timeOfAccident">Время пожара.</param>
        /// <param name="timeOfCall">Время вызова.</param>
        /// <param name="timeOfDeparture">Время убытия подразделения.</param>
        /// <param name="timeOfArrival">Время прибытия первого подразделения.</param>
        /// <param name="waterFeedTime">Время подачи первого ствола.</param>
        /// <param name="localizationTime">Время локализации.</param>
        /// <param name="liquidationTime">Время ликвидации.</param>
        /// <param name="endOfWorkTime">Время полной ликвидации. Сбор ПТВ. Возвращение в часть.</param>
        /// <param name="applicant">Заявитель.</param>
        /// <param name="owner">Владелец объекта.</param>
        /// <param name="causeOfFire">Причина пожара.</param>
        /// <param name="costOfDamage">Ущерб.</param>
        /// <param name="lostInFire">Уничтоженно огнем.</param>
        /// <param name="costOfSalvage">Спасено.</param>
        /// <param name="saved">Спасено от огня.</param>
        /// <param name="fightingLeader"></param>
        /// <param name="fireInspector"></param>
        public Fire(string adress,
                    string fireRank,
                    DateTime date, 
                    DateTime timeOfAccident, 
                    DateTime timeOfCall,
                    DateTime timeOfDeparture,
                    DateTime timeOfArrival,
                    DateTime waterFeedTime,
                    DateTime localizationTime,
                    DateTime liquidationTime,
                    DateTime endOfWorkTime,
                    Applicant applicant,
                    string owner,
                    string causeOfFire,
                    ulong costOfDamage,
                    string lostInFire,
                    ulong costOfSalvage,
                    string saved,
                    ICollection<Employee> fightingLeader,
                    ICollection<Employee> fireInspector)
        {
            #region Проверка - IsNullOrWhiteSpace 
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new ArgumentException($"'{nameof(adress)}' не может быть пустым или содержать только пробел", nameof(adress));
            }

            if (string.IsNullOrWhiteSpace(fireRank))
            {
                throw new ArgumentException($"'{nameof(fireRank)}' не может быть пустым или содержать только пробел", nameof(fireRank));
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException($"'{nameof(owner)}' не может быть пустым или содержать только пробел", nameof(owner));
            }

            if (string.IsNullOrWhiteSpace(causeOfFire))
            {
                throw new ArgumentException($"'{nameof(causeOfFire)}' не может быть пустым или содержать только пробел", nameof(causeOfFire));
            }

            if (string.IsNullOrWhiteSpace(lostInFire))
            {
                throw new ArgumentException($"'{nameof(lostInFire)}' не может быть пустым или содержать только пробел", nameof(lostInFire));
            }

            if (string.IsNullOrWhiteSpace(saved))
            {
                throw new ArgumentException($"'{nameof(saved)}' не может быть пустым или содержать только пробел", nameof(saved));
            }
            #endregion

            #region Инициализация свойств
            Adress = adress;
            Date = date;
            TimeOfAccident = timeOfAccident;
            TimeOfCall = timeOfCall;
            TimeOfArrival = timeOfArrival;
            TimeOfDeparture = timeOfDeparture;
            FireRank = fireRank;
            WaterFeedTime = waterFeedTime;
            LocalizationTime = localizationTime;
            LiquidationTime = liquidationTime;
            EndOfWorkTime = endOfWorkTime;
            Applicant = applicant ?? throw new ArgumentNullException($"'{nameof(applicant)}' не может быть NULL", nameof(applicant));
            Owner = owner;
            CauseOfFire = causeOfFire;
            CostOfDamage = costOfDamage;
            LostInFire = lostInFire;
            CostOfSalvage = costOfSalvage;
            Saved = saved;
            FightingLeader = fightingLeader ?? throw new ArgumentNullException($"'{nameof(fightingLeader)}' не может быть NULL", nameof(fightingLeader));
            FireInspector = fireInspector ?? throw new ArgumentNullException($"'{nameof(fireInspector)}' не может быть NULL", nameof(fireInspector)); 
            #endregion
        }
    }
}
