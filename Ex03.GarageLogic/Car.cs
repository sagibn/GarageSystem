using System;
using Ex03.GarageLogic.Properties;

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
		eCarColor m_CarColor;

		public Car(CarProperties i_CarProperties, EnergySource i_Engine)
			: base(i_CarProperties.ModelName, i_CarProperties.LicenseNumber, i_Engine)
		{
			SetWheels(5, i_CarProperties.WheelManufactureName, i_CarProperties.WheelCurrAirPressure, i_CarProperties.WheelMaxAirPressure);
			m_CarColor = i_CarProperties.CarColor;
			if(i_CarProperties.NumOfDoors > 1 || i_CarProperties.NumOfDoors < 6)
            {
				m_NumOfDoors = i_CarProperties.NumOfDoors;
			}
            else
            {
				throw new Exceptions.ValueOutOfRangeException(2, 5, i_CarProperties.NumOfDoors);
            }
		}

		public eCarColor CarColor
		{
			get
			{
				return m_CarColor;
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
Color of the car: {3}", base.GetVehicleData(), Engine.ToString(), m_NumOfDoors, m_CarColor);

			return carData;
		}
	}
}
