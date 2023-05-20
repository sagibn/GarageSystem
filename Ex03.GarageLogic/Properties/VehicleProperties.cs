using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Properties
{
    public class VehicleProperties
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private string m_WheelManufactureName;
        private float m_WheelCurrAirPressure;
        private float m_WheelMaxAirPressure;
        private float m_CurrEnergy;

        public VehicleProperties(string i_ModelName,
            string i_LicenseNumber, string i_WheelManufactureName, float i_WheelCurrAirPressure,
            float i_WheelMaxAirPressure, float i_CurrEnergy)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_WheelManufactureName = i_WheelManufactureName;
            m_WheelCurrAirPressure = i_WheelCurrAirPressure;
            m_WheelMaxAirPressure = i_WheelMaxAirPressure;
            m_CurrEnergy = i_CurrEnergy;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public string WheelManufactureName
        {
            get
            {
                return m_WheelManufactureName;
            }
        }

        public float WheelCurrAirPressure
        {
            get
            {
                return m_WheelCurrAirPressure;
            }
        }

        public float WheelMaxAirPressure
        {
            get
            {
                return m_WheelMaxAirPressure;
            }
        }

        public float CurrEnergy
        {
            get
            {
                return m_CurrEnergy;
            }
        }
    }
}
