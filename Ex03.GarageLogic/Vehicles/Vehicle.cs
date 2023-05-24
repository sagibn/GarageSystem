using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenseNumber;
        float m_EnergyPercentage;
        EnergySource m_Engine;
        List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber, EnergySource i_Engine)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            m_EnergyPercentage = m_Engine.EnergyPercentage;
            m_Wheels = new List<Wheel>();
        }

        public EnergySource Engine
        {
            get
            {
                return m_Engine;
            }
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

        public List<Wheel> Wheels
        {
            set
            {
                m_Wheels = value;
            }

            get
            {
                return m_Wheels;
            }
        }

        public void SetWheels(uint i_NumOfWheels ,string i_ManufactureName, float i_CurrAirPressure, float i_MaxAirPressure)
        {
            for(int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_ManufactureName, i_CurrAirPressure, i_MaxAirPressure);

                Wheels.Add(wheel);
            }
        }

        private StringBuilder wheelsData()
        {
            StringBuilder wheelsData = new StringBuilder();
            string data = string.Empty;
            int wheelNumber = 1;

            foreach(Wheel wheel in Wheels)
            {
                data = string.Format("Wheel number {0} - {1}{2}", wheelNumber, wheel.ToString(), Environment.NewLine);
                wheelsData.Append(data);
                wheelNumber++;
            }

            return wheelsData;
        }

        public virtual string GetVehicleData()
        {
            string vehicleData = string.Format(@"License number: {0}
Vehicle model name: {1}
Wheels information:
{2}", m_LicenseNumber, m_ModelName, wheelsData());

            return vehicleData;
        }
    }
}
