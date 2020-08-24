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
       /// <summary> Ранг пожара.</summary>
        public string FireRank { get; set; }

        /// <summary> Время подачи первого ствола. </summary>
        public DateTime WaterFeedTime { get; set; }

        /// <summary> Время локализации. </summary>
        public DateTime LocalizationTime { get; set; }

        /// <summary> Время ликвидации. </summary>
        public DateTime LiquidationTime { get; set; }

        /// <summary> Время полной ликвидации пожара. Сбор ПТВ. Возвращение в часть. </summary>
        public DateTime EndOfWorkTime { get; set; }

        /// <summary> Задействованные подразделения. </summary>
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

        /// <summary> Спасено. </summary>
        public ulong CostOfSalvage { get; set; }

        /// <summary> Руководитель тушения пожара (РТП). </summary>
        public List<Employee> FightingLeader { get; set; }

        /// <summary> Разбирались. </summary>
        public List<Employee> FireInspector { get; set; }

        /// <summary>  внесший пожар/изменения. </summary>
        public int UserId { get; set; }
    

        public Fire(string adress,
                    DateTime date, 
                    DateTime timeOfAccident, 
                    DateTime timeOfCall,
                    DateTime timeOfArrival,
                    DateTime waterFeedTime,
                    DateTime localizationTime,
                    DateTime liquidationTime,
                    DateTime endOfWorkTime,
                    Applicant applicant,
                    string owner,
                    string causeOfFire,
                    ulong costOfDamage,
                    ulong costOfSalvage,
                    List<Employee> fightingLeader,
                    List<Employee> fireInspector)
        {
            if (string.IsNullOrWhiteSpace(adress))
            {
                throw new ArgumentException($"'{nameof(adress)}' не может быть пустым или содержать только пробел", nameof(adress));
            }

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException($"'{nameof(owner)}' не может быть пустым или содержать только пробел", nameof(owner));
            }

            if (string.IsNullOrWhiteSpace(causeOfFire))
            {
                throw new ArgumentException($"'{nameof(causeOfFire)}' не может быть пустым или содержать только пробел", nameof(causeOfFire));
            }

            Adress = adress;
            Date = date;
            TimeOfAccident = timeOfAccident;
            TimeOfCall = timeOfCall;
            TimeOfArrival = timeOfArrival;
            WaterFeedTime = waterFeedTime;
            LocalizationTime = localizationTime;
            LiquidationTime = liquidationTime;
            EndOfWorkTime = endOfWorkTime;
            Applicant = applicant ?? throw new ArgumentNullException($"'{nameof(applicant)}' не может быть NULL", nameof(applicant));
            Owner = owner;
            CauseOfFire = causeOfFire;
            CostOfDamage = costOfDamage;
            CostOfSalvage = costOfSalvage;
            FightingLeader = fightingLeader ?? throw new ArgumentNullException($"'{nameof(fightingLeader)}' не может быть NULL", nameof(fightingLeader));
            FireInspector = fireInspector ?? throw new ArgumentNullException($"'{nameof(fireInspector)}' не может быть NULL", nameof(fireInspector));
        }
    }
}
