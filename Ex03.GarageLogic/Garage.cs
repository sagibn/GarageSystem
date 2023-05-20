using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Properties;

namespace Ex03.GarageLogic
{
	public class Garage
	{
        public enum eVehicleTypes
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelTruck
        }

        private Dictionary<string, CarDetails> m_CustomerListByLicenseNumber;
        private VehicleGenerator m_VehicleGenerator;
        private Dictionary<int, string> m_Services;

        public Garage()
        {
            m_CustomerListByLicenseNumber = null;
            m_VehicleGenerator = new VehicleGenerator();
            m_Services = new Dictionary<int, string>
            {
                { 1, "Add new car to the garage." },
                { 2, "Display the list of the license numbers of the vehicles, by their status." },
                { 3, "Change the status of the vehicle." },
                { 4, "Inflate tires to maximum." },
                { 5, "Refuel a vehicle." },
                { 6, "Rechange a vehicle." },
                { 7, "Display vehicle's information." },
                { 8, "Exit." }
            };
        }
    }
}