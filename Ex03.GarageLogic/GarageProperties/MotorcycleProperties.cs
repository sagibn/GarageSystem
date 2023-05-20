using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorcycleProperties : VehicleProperties
    {
        Motorcycle.eLicenseType m_LicenseType;
        int m_EngineCapacity;

        public MotorcycleProperties(Motorcycle.eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName,
            string i_LicenseNumber, string i_WheelManufactureName, float i_WheelCurrAirPressure, float i_CurrEnergy)
            : base(i_ModelName, i_LicenseNumber, i_WheelManufactureName, i_WheelCurrAirPressure, 31.0f, i_CurrEnergy)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public Motorcycle.eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }
    }
}