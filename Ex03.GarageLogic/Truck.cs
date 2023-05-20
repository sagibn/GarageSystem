using System;

namespace Ex03.GarageLogic
{

	public class Truck : Vehicle
	{
		bool m_HazardElements;
		float m_CargoVolume;

		public Car(string i_ManufactureName, float i_CurrAirPressure, 
			string i_ModelName, string i_LicenceNumber, EnergySource i_Engine, 
			float i_CargoVolume, bool i_HazardElements) : base(i_ModelName, i_LicenceNumber, i_Engine)
		{
			SetWheels(14, i_ManufactureName, i_CurrAirPressure, 26.0f);
			m_CargoVolume = i_CargoVolume;
			m_HazardElements = i_HazardElements;
		}

		public bool HazardElements
		{
			get
			{
				return m_HazardElements;
			}
		}

		public bool CargoVolume
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
