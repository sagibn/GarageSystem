﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }

        eLicenseType m_LicenseType;
        int m_EngineCapacity;

        public Motorcycle(MotorcycleProperties i_MotorcycleProperties, EnergySource i_Engine) 
            : base(i_MotorcycleProperties.ModelName, i_MotorcycleProperties.LicenseNumber, i_Engine)
        {
            m_LicenseType = i_MotorcycleProperties.LicenseType;
            m_EngineCapacity = i_MotorcycleProperties.EngineCapacity;
            SetWheels(2, i_MotorcycleProperties.WheelManufactureName, i_MotorcycleProperties.WheelCurrAirPressure, i_MotorcycleProperties.WheelMaxAirPressure);
        }

        public eLicenseType LicenseType
        {
            get
            {

                return m_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {

                return m_EngineCapacity;
            }
        }

        public override string GetVehicleData()
        {
            string motorcycleData = string.Format(@"Motorcycle:
{0}
{1}
License type: {2}
Engine capacity: {3}", base.GetVehicleData(), Engine.ToString(), m_LicenseType, m_EngineCapacity);

            return motorcycleData;
        }
    }
}