﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
    }
    public class FuelEngine : EnergySource
    {
        private eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_CurrFuel, float i_MaxFuel) : base(i_CurrFuel, i_MaxFuel)
        {
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public void AddFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (!m_FuelType.Equals(i_FuelType))
            {
                throw new ArgumentException("Provided wrong fuel type.");
            }

            AddEnergy(i_FuelToAdd);
        }

        public override string ToString()
        {
            return string.Format("Fuel engine: fuel type-{0}, remaining fuel in the tank-{1}% ({2} liters.)", m_FuelType, EnergyPercentage, CurrEnergy);
        }
    }
}
