using System;

namespace Ex03.GarageLogic
{
	public enum eCarColor
	{ 
		White,
		Black,
		Yellow,
		Red
	}
	public class Car : Vehicle
	{
		int m_NumOfDoors;
		eCarColor m_ColorOfCar;

		public Car(eCarColor i_CarColor, int i_NumOfDoors, string i_ManufactureName, float i_CurrAirPressure, string i_ModelName,
			string i_LicenceNumber, EnergySource i_Engine)
			: base(i_ModelName, i_LicenceNumber, i_Engine)
		{
			SetWheels(5, i_ManufactureName, i_CurrAirPressure, 33.0f);
			m_ColorOfCar = i_CarColor;
			m_NumOfDoors = i_NumOfDoors;
		}

		public eCarColor CarColor
		{
			get
			{
				return m_ColorOfCar;
			}
		}

		public int NumOfDoors
		{
			get
			{
				return m_NumOfDoors;
			}
		}

		public override string GetVehicleData()
		{
			string carData = string.Format(@"Car:
{0}
{1}
Number of doors: {2}
Color of the car: {3}", base.GetVehicleData(), Engine.ToString(), m_NumOfDoors, m_ColorOfCar);

			return carData;
		}
	}
}
