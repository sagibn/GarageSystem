using System;
using Ex03.GarageLogic.Properties;

namespace Ex03.GarageLogic
{

	public class Truck : Vehicle
	{
		bool m_HazardElements;
		float m_CargoVolume;

		public Truck(TruckProperties i_TruckProperties, EnergySource i_Engine)
			: base(i_TruckProperties.ModelName, i_TruckProperties.LicenseNumber, i_Engine)
		{
			SetWheels(14, i_TruckProperties.WheelManufactureName, i_TruckProperties.WheelCurrAirPressure, i_TruckProperties.WheelMaxAirPressure);
			m_CargoVolume = i_TruckProperties.CargoVolume;
			m_HazardElements = i_TruckProperties.HazardElements;
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

		public override string GetVehicleData()
		{
			string truckData = string.Format(@"Truck:
{0}
{1}
Contains hazard elements: {2}
Cargo volume: {3}", base.GetVehicleData(), Engine.ToString(), m_HazardElements, m_CargoVolume);

			return truckData;
		}
	}
}
