using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Properties
{
    public class TruckProperties : VehicleProperties
    {
        bool m_HazardElements;
        float m_CargoVolume;

        public TruckProperties(bool i_HazardElements, float i_CargoVolume, string i_ModelName,
            string i_LicenseNumber, string i_WheelManufactureName, float i_WheelCurrAirPressure, float i_CurrEnergy)
            : base(i_ModelName, i_LicenseNumber, i_WheelManufactureName, i_WheelCurrAirPressure, 26.0f, i_CurrEnergy)
        {
            m_HazardElements = i_HazardElements;
            m_CargoVolume = i_CargoVolume;
        }

        public bool HazardElements
        {
            get
            {
                return m_HazardElements;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
        }
    }
}