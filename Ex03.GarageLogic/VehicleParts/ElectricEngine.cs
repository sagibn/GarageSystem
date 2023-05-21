using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : EnergySource
    {
        public ElectricEngine(float i_CurrBatteryTime, float i_MaxBatteryTime) : base(i_CurrBatteryTime, i_MaxBatteryTime)
        {
        }

        public void ChargeBattery(float i_HoursOfEnergyToCharge)
        {
            AddEnergy(i_HoursOfEnergyToCharge);
        }

        public override string ToString()
        {
            return string.Format("Electric engine: remaining battery in the tank-{0}% ({1} hours.)", EnergyPercentage, CurrEnergy);
        }
    }
}
