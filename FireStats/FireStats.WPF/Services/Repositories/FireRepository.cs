
using FireStats.WPF.Models.Applicants;
using FireStats.WPF.Services.Base;
using FireStats.WPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Services.Repositories
{
    class FireRepository : RepositoryInMemory<Fire>
    {
        protected override void Update(Fire Source, Fire Destination)
        {
            Destination.Adress = Source.Adress;
            Destination.Applicant = Source.Applicant;
            Destination.CauseOfFire = Source.CauseOfFire;
            Destination.CostOfDamage = Source.CostOfDamage;
            Destination.CostOfSalvage = Source.CostOfSalvage;
            Destination.Date = Source.Date;
            Destination.DeceasedList = Source.DeceasedList;
            Destination.EndOfWorkTime = Source.EndOfWorkTime;
            Destination.FightingLeader = Source.FightingLeader;
            Destination.FireInspector = Source.FireInspector;
            Destination.FireRank = Source.FireRank;
            Destination.Injureds = Source.Injureds;
            Destination.LiquidationTime = Source.LiquidationTime;
            Destination.LocalizationTime = Source.LocalizationTime;
            Destination.LostInFire = Source.LostInFire;
            Destination.Owner = Source.Owner;
            Destination.Result = Source.Result;
            Destination.Saved = Source.Saved;
            Destination.TimeOfAccident = Source.TimeOfAccident;
            Destination.TimeOfArrival = Source.TimeOfArrival;
            Destination.TimeOfCall = Source.TimeOfCall;
            Destination.TimeOfDeparture = Source.TimeOfDeparture;
            Destination.UserId = Source.UserId;
            Destination.WaterFeedTime = Source.WaterFeedTime;
        }
    }
}
