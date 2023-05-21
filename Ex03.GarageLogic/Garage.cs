using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;

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

        private Dictionary<string, CustomerInfo> m_CustomerListByLicenseNumber;
        private readonly VehicleGenerator m_VehicleGenerator;
        private Dictionary<int, string> m_Services;

        public Garage()
        {
            m_CustomerListByLicenseNumber = null;
            m_VehicleGenerator = new VehicleGenerator();
            m_Services = new Dictionary<int, string>
            {
                { 1, "1. Add new vehicle to the garage." },
                { 2, "2. Display the list of the license numbers of the vehicles, by their status." },
                { 3, "3. Change the status of the vehicle." },
                { 4, "4. Inflate tires to maximum." },
                { 5, "5. Refuel a vehicle." },
                { 6, "6. Rechange a vehicle." },
                { 7, "7. Display vehicle's information." },
                { 8, "8. Exit." }
            };
        }

        public Dictionary<int, string> Services
        {
            get
            {
                return m_Services;
            }
        }

        public void AddVehicleToGarage(eVehicleTypes i_VehicleTypes, VehicleProperties i_VehicleProperties, string i_OwnerName, string i_PhoneNumber)
        {
            bool vehicleExists = CheckIfVehicleExists(i_VehicleProperties.LicenseNumber);

            if(vehicleExists)
            {
                throw new VehicleAlreadyExistsException(i_VehicleProperties.LicenseNumber);
            }

            Vehicle vehicle = m_VehicleGenerator.GenerateVehicle(i_VehicleTypes, i_VehicleProperties);
            CustomerInfo newCustomer = new CustomerInfo(i_OwnerName, i_PhoneNumber, vehicle);

            m_CustomerListByLicenseNumber.Add(newCustomer.Vehicle.LicenceNumber, newCustomer);
        }

        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool vehicleExists = m_CustomerListByLicenseNumber.TryGetValue(i_LicenseNumber, out CustomerInfo customer);

            if(vehicleExists)
            {
                customer.VehicleStatus = eVehicleStatus.InRepair;
            }

            return vehicleExists;
        }

        public List<string> FilterLicenseNumberByStatus(eVehicleStatus? i_VehicleStatus)
        {
            List<string> licenseNumbers = new List<string>();

            if(!i_VehicleStatus.HasValue)
            {
                foreach(CustomerInfo customer in m_CustomerListByLicenseNumber.Values)
                {
                    licenseNumbers.Add(customer.Vehicle.LicenceNumber);
                }
            }
            else
            {
                foreach(CustomerInfo customer in m_CustomerListByLicenseNumber.Values)
                {
                    if(customer.VehicleStatus == i_VehicleStatus)
                    {
                        licenseNumbers.Add(customer.Vehicle.LicenceNumber);
                    }
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
            CustomerInfo customer = GetCustomer(i_LicenseNumber);

            customer.VehicleStatus = i_NewVehicleStatus;
        }

        public void InflateTiresToMax(string i_LicenseNumber)
        {
            CustomerInfo customer = GetCustomer(i_LicenseNumber);

            foreach (Wheel wheel in customer.Vehicle.Wheels)
            {
                wheel.InflateTireToMax();
            }
        }

        public void Refuel(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            CustomerInfo customer = GetCustomer(i_LicenseNumber);

            if (customer.Vehicle.Engine is FuelEngine fuelEngine)
            {
                fuelEngine.AddFuel(i_AmountOfFuelToAdd, i_FuelType);
            }
            else
            {
                throw new Exception("Trying to add fuel to an electric engine.");
            }
        }

        public void Recharge(string i_LicenseNumber, float i_MinutesToCharge)
        {
            CustomerInfo customer = GetCustomer(i_LicenseNumber);

            if (customer.Vehicle.Engine is ElectricEngine electricEngine)
            {
                electricEngine.ChargeBattery(i_MinutesToCharge / 60.0f);
            }
        }

        public string DisplayVehicleInformation(string i_LicenseNumber)
        {
            CustomerInfo customer = GetCustomer(i_LicenseNumber);
            string fullVehicleData = customer.ToString();

            return fullVehicleData;
        }

        private CustomerInfo GetCustomer(string i_LicenseNumber)
        {
            bool vehicleExists = m_CustomerListByLicenseNumber.TryGetValue(i_LicenseNumber, out CustomerInfo customer);

            if (!vehicleExists)
            {
                throw new Exception(string.Format("Vehicle with license number of {0} is not exist!", i_LicenseNumber));
            }

            return customer;
        }
    }
}