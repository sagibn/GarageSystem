using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic
{
    public struct Wheel
    {
        private string m_ManufactureName;
        private float m_CurrAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufactureName, float i_CurrAirPressure, float i_MaxAirPressure)
        {
            if(i_CurrAirPressure > i_MaxAirPressure)
            {
                throw new ArgumentException(string.Format("Current air pressure cannot be over the max air pressure that the manufacturer recommend({0} psi).", i_MaxAirPressure));
            }

            m_ManufactureName = i_ManufactureName;
            m_CurrAirPressure = i_CurrAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufactureName
        {
            get
            {
                return m_ManufactureName;
            }
        }

        public void InflateTire(float i_AirPressureToAdd)
        {
            if(m_CurrAirPressure + i_AirPressureToAdd <= m_MaxAirPressure)
            {
                m_CurrAirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure, m_CurrAirPressure + i_AirPressureToAdd);
            }
        }

        public void InflateTireToMax()
        {
            InflateTire(m_MaxAirPressure - m_CurrAirPressure);
        }

        public override string ToString()
        { 
            return string.Format("wheel manufacture name: {0}, current air pressure: {1}, max air pressure: {2}"
                , m_ManufactureName, m_CurrAirPressure, m_MaxAirPressure);
        }
    }
}
