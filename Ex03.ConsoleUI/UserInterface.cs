using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic;
using System;
using System.Collections.Generic;


namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        private readonly Garage  m_Garage = new Garage();

        public void Run()
        {
            while(true)
            {
                try
                {
                    MainMenu();
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void MainMenu()
        {
            Dictionary<int, string> services = m_Garage.Services;
            string userInput;

            Console.Clear();
            Console.WriteLine("Welcome to Geek's garage, here are all of our services.");
            foreach(var kvp in services)
            {
                Console.WriteLine("{0}:{1}", kvp.Key, kvp.Value);
            }

            while(true)
            {
                Console.WriteLine("Please choose the desired service.");
                userInput = Console.ReadLine();
          
                switch(userInput)
                {
                    case "1":
                        AddNewVehicleToGarage();
                        break;
                    case "2":
                        ShowVehiclesInGarage();
                        break;
                    case "3":
                        ChangeVehicleStatus();
                        break;
                    case "4":
                        InflateTiersToMax();
                        break;
                    case "5":
                        RefuelVehicle();
                        break;
                    case "6":
                        RechargeVehicle();
                        break;
                    case "7":
                        DisplayVehicleInfo();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Wrong input. Please try again.");
                        break;
                }
            }
        }

        private void AddNewVehicleToGarage()
        {
            string licenseNumber, ownerName, PhoneNumber;
            VehicleProperties vehicleProperties;
            Garage.eVehicleTypes vehicleType;

            Console.WriteLine("Please provide the license number of the car you wish to add to the garage.");
            licenseNumber = Console.ReadLine();
            if(m_Garage.CheckIfVehicleExists(licenseNumber))
            {
                Console.WriteLine("Vehicle already exists in the garage.");
            }
            else
            {
                GetInfoFromCustomer(licenseNumber,out vehicleType, out vehicleProperties, out ownerName, out PhoneNumber);
                try
                {
                    m_Garage.AddVehicleToGarage(vehicleType, vehicleProperties, ownerName, PhoneNumber);
                    Console.WriteLine("Added new vehicle succesfully.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GetInfoFromCustomer(string i_LicensePlate, out Garage.eVehicleTypes io_VehicleType,
            out VehicleProperties io_VehicleProperties, out string io_OwnerName, out string io_PhoneNumber)
        {
            while(true)
            {
                try
                {
                    GetOwnerPhoneAndName(out io_PhoneNumber, out io_OwnerName);
                    break;
                }
                catch(FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

            while(true)
            {
                try
                {
                    io_VehicleType = GetVehicleType();
                    break;
                }
                catch(ArgumentException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

            while(true)
            {
                try
                {
                    if(io_VehicleType == Garage.eVehicleTypes.ElectricCar || io_VehicleType == Garage.eVehicleTypes.FuelCar)
                    {
                        io_VehicleProperties = GetCarProperties(i_LicensePlate);
                    }
                    else if(io_VehicleType == Garage.eVehicleTypes.FuelMotorcycle || io_VehicleType == Garage.eVehicleTypes.ElectricMotorcycle)
                    {
                        io_VehicleProperties = GetMotorcycleProperties(i_LicensePlate);
                    }
                    else if(io_VehicleType == Garage.eVehicleTypes.FuelTruck)
                    {
                        io_VehicleProperties = GetTruckProperties(i_LicensePlate);
                    }
                    else
                    {
                        io_VehicleProperties = null;
                    }

                    break;
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private Garage.eVehicleTypes GetVehicleType()
        {
            string userInput;
            Garage.eVehicleTypes vehicleType;

            Console.WriteLine("Please select the type of the car:");
            Console.WriteLine("For fuel car please press 1");
            Console.WriteLine("For electric car please press 2");
            Console.WriteLine("For fuel motorcycle please press 3");
            Console.WriteLine("For electric motorcycle please press 4");
            Console.WriteLine("For truck please press 5");
            userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1":
                    vehicleType = Garage.eVehicleTypes.FuelCar;
                    break;
                case "2":
                    vehicleType = Garage.eVehicleTypes.ElectricCar;
                    break;
                case "3":
                    vehicleType = Garage.eVehicleTypes.FuelMotorcycle;
                    break;
                case "4":
                    vehicleType = Garage.eVehicleTypes.ElectricMotorcycle;
                    break;
                case "5":
                    vehicleType = Garage.eVehicleTypes.FuelTruck;
                    break;
                default:
                    throw new ArgumentException("Type of car should be a number between 1 to 5.");
            }

            return vehicleType;
        }

        //private void GetOwnerPhoneAndName(out string o_OwnerPhone, out string o_OwnerName)
        //{
        //    string ownerLastName;

        //    Console.WriteLine("Please provide the owner's first name.");
        //    o_OwnerName = Console.ReadLine();
        //    foreach(char c in o_OwnerName)
        //    {
        //        if(c < 65 || 90 < c)
        //        {
        //            throw new FormatException("Owner first name must only contain alph bet characters.");
        //        }
        //    }

        //    Console.WriteLine("Please provide the owner's last name.");
        //    ownerLastName = Console.ReadLine();
        //    foreach(char c in ownerLastName)
        //    {
        //        if(c < 65 || 90 < c)
        //        {
        //            throw new FormatException("Owner last name must only contain alph bet characters.");
        //        }
        //    }

        //    o_OwnerName = o_OwnerName + ' ' + ownerLastName;
        //    Console.WriteLine("Please provide owner's Phone");
        //    o_OwnerPhone = Console.ReadLine();
        //    foreach(char c in o_OwnerPhone)
        //    {
        //        if(c < 0 || 9 < c)
        //        {
        //            throw new FormatException("Phone number must be integers only.");
        //        }
        //    }
        //}

        private CarProperties GetCarProperties(string i_LicensePlate)
        {
            eCarColor carColor;
            string modelName;
            string wheelManufactureName;

            Console.WriteLine("Please provide the number of doors:");
            if(!int.TryParse(Console.ReadLine(), out int numOfDoors))
            {
                throw new FormatException("Number of doors most be an int.");
            }

            if(numOfDoors < 2 || numOfDoors > 5)
            {
                throw new ValueOutOfRangeException(2, 5, numOfDoors);
            }

            Console.WriteLine("Please provide the model name:");
            modelName = Console.ReadLine();
            Console.WriteLine("Please provide the wheel manufacturer name.");
            wheelManufactureName = Console.ReadLine();
            Console.WriteLine("Please provide the wheel current air pressure:");
            if(!float.TryParse(Console.ReadLine(), out float wheelCurrAirPressure))
            {
                throw new FormatException("air pressure must be a float.");
            }

            Console.WriteLine("Please provide the current energy(amount of fuel/battery time):");
            if(!float.TryParse(Console.ReadLine(), out float currEnergy))
            {
                throw new FormatException("energy must be a float.");
            }

            carColor = GetCarColor();

            return new CarProperties(numOfDoors, carColor, modelName, i_LicensePlate, wheelManufactureName, wheelCurrAirPressure, currEnergy);
        }
        private eCarColor GetCarColor()
        {
            string userInput;

            while(true)
            {
                Console.WriteLine("For the color white press 1.");
                Console.WriteLine("For the color black press 2.");
                Console.WriteLine("For the color red press 3.");
                Console.WriteLine("For the color yellow press 4.");
                userInput = Console.ReadLine();
                if(userInput == "1")
                {
                    return eCarColor.White;
                }
                else if(userInput == "2")
                {
                    return eCarColor.Black;
                }
                else if(userInput == "3")
                {
                    return eCarColor.Red;
                }
                else if(userInput == "4")
                {
                    return eCarColor.Yellow;
                }
                else
                {
                    Console.WriteLine("Invlaid Input.");
                }
            }
        }
        private MotorcycleProperties GetMotorcycleProperties(string i_LicensePlate)
        {
            Motorcycle.eLicenseType licenseType;
            int engineCapacity;
            string modelName;
            string wheelManufactureName;

            Console.WriteLine("Please provide the model name.");
            modelName = Console.ReadLine();
            Console.WriteLine("Please provide the wheel manufacture name.");
            wheelManufactureName = Console.ReadLine();
            Console.WriteLine("Please provide the wheel current air pressure.");
            if(!float.TryParse(Console.ReadLine(), out float wheelCurrAirPressure))
            {
                throw new FormatException("air pressure must be a float");
            }

            Console.WriteLine("Please provide the current energy .");
            if(!float.TryParse(Console.ReadLine(), out float currEnergy))
            {
                throw new FormatException("energy must be a float");
            }

            licenseType = GetLicenseType();
            while(true)
            {
                try
                {
                    engineCapacity = GetEngineCap();
                    break;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return new Ex03.GarageLogic.MotorcycleProperties(licenseType, engineCapacity, modelName, i_LicensePlate, wheelManufactureName, wheelCurrAirPressure, currEnergy);
        }

        private Ex03.GarageLogic.Motorcycle.eLicenseType GetLicenseType()
        {
            string input;

            while(true)
            {
                Console.WriteLine("Please provide the license type of the motorcycle.");
                Console.WriteLine("For A1 please press 1.");
                Console.WriteLine("For A2 please press 2.");
                Console.WriteLine("For AA please press 3.");
                Console.WriteLine("For B1 please press 4.");
                input = Console.ReadLine();
                if(input == "1")
                {
                    return GarageLogic.Motorcycle.eLicenseType.A1;
                }
                else if(input == "2")
                {
                    return GarageLogic.Motorcycle.eLicenseType.A2;
                }
                else if(input == "3")
                {
                    return GarageLogic.Motorcycle.eLicenseType.AA;
                }
                else if(input == "4")
                {
                    return GarageLogic.Motorcycle.eLicenseType.B1;
                }
                else
                {
                    Console.WriteLine("Please provide a valid license type");
                }

            }
        }

        private int GetEngineCap()
        {

            Console.WriteLine("Please provide the engine capacity.");

            if (!int.TryParse(Console.ReadLine(), out int engineCap))
            {
                throw new FormatException("Engine capacity must be a int.");
            }

            return engineCap;
        }

        private Ex03.GarageLogic.TruckProperties GetTruckProperties(string i_LicensePlate)
        {
            float cargoVolume;
            string modelName;
            string wheelManufactureName;

            Console.WriteLine("Please provide the model name.");
            modelName = Console.ReadLine();
            Console.WriteLine("Please provide the wheel manufacture name.");
            wheelManufactureName = Console.ReadLine();
            Console.WriteLine("Please provide the wheel current air pressure.");
            if(!float.TryParse(Console.ReadLine(), out float wheelCurrAirPressure))
            {
                throw new FormatException("air pressure must be a float");
            }

            Console.WriteLine("Please provide the current energy .");
            if(!float.TryParse(Console.ReadLine(), out float currEnergy))
            {
                throw new FormatException("energy must be a float");
            }

            ContainsHazardElements(out bool hazardElements);
            while(true)
            {
                try
                {
                    GetCargoVolume(out cargoVolume);
                    break;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return new Ex03.GarageLogic.TruckProperties(hazardElements, cargoVolume, modelName, i_LicensePlate, wheelManufactureName, wheelCurrAirPressure, currEnergy);
        }

        private void ContainsHazardElements(out bool o_HazardElements)
        {
            string input;

            while(true)
            {
                Console.WriteLine("Press 1 if the cargo has hazard elements or 0 if it doesnt");
                input = Console.ReadLine();
                if(input == "1")
                {
                    o_HazardElements = true;
                    return;
                }
                else if(input == "0")
                {
                    o_HazardElements = false;
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input please try again");
                }
            }    
        }
       
        private void GetCargoVolume(out float o_CargoVolume)
        {

            Console.WriteLine("Please provide the cargo volume.");
            if (!float.TryParse(Console.ReadLine(), out o_CargoVolume))
            {
                throw new FormatException("Cargo volume must be a int.");
            }
        }
        private void ShowVehiclesInGarage()
        {
            //TO DO ASK SAGI FOR ALGORITHM.
        }

        private void ChangeVehicleStatus()
        {
            string licenseNumber;

            Console.WriteLine("Please provide the vehicle license Plate.");
            licenseNumber = Console.ReadLine();
            try
            {
                m_Garage.CheckIfVehicleExists(licenseNumber);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            GetVehicleStatusFromUser(out GarageLogic.eVehicleStatus newVehicleStatus);

            try
                {
                    m_Garage.ChangeVehicleStatus(licenseNumber, newVehicleStatus);
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("License number does not exist on garage");
                }
            
        }

        private void GetVehicleStatusFromUser(out GarageLogic.eVehicleStatus o_VehicleStatus)
        {
            int userChoice = 0;
            bool v_ValidInput = false;

            Console.WriteLine(" Please choose vehicle status:");
            Console.WriteLine("1. In service");
            Console.WriteLine("2. Fixed");
            Console.WriteLine("3. Paid");
            
            while(v_ValidInput == false)
            {
                try
                {
                    v_ValidInput = GetValidIntFromUserInRange(out userChoice, 1, 3);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The choice should be between " + ex.MinValue + " to " + ex.MaxValue);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            o_VehicleStatus = (GarageLogic.eVehicleStatus)userChoice;
        }
        private bool GetValidIntFromUserInRange(out int o_UserInput, int i_MinValue, int i_MaxValue)
        {
            if(int.TryParse(Console.ReadLine(), out o_UserInput) == false)
            {
                throw new FormatException();
            }

            if(o_UserInput < i_MinValue || o_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue, o_UserInput);
            }

            return true;
        }
        private bool GetValidFloatFromUserInRange(out float o_UserInput, float i_MinValue, float i_MaxValue)
        {
            if(float.TryParse(Console.ReadLine(), out o_UserInput) == false)
            {
                throw new FormatException();
            }

            if(o_UserInput < i_MinValue || o_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue, o_UserInput);
            }

            return true;
        }

        private void InflateTiersToMax()
        {
            string licenseNumber;

            Console.Clear();
            try
            {
                Console.WriteLine("Please provide the license number.");
                licenseNumber = Console.ReadLine();
                m_Garage.InflateTiresToMax(licenseNumber);
                Console.WriteLine("Vehicles wheels inflated to max successfuly");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void RefuelVehicle()
        {
            string licenseNumber;

            Console.WriteLine("Please provide vehicle license.");
            licenseNumber = Console.ReadLine();
            GetFuelTypeFromUser(out GarageLogic.eFuelType fuelType);
            GetAmountOfFuelToAddFromUser(out float fuelToAdd);

            try
            {
                m_Garage.Refuel(licenseNumber, fuelType, fuelToAdd);
                Console.WriteLine("Vehicle fueled successfuly");
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("License Number does not exist in the garage");
            }
            catch(ArgumentNullException)
            {   
                Console.WriteLine("The vehicle has no fuel tank");
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine("Cannot fuel vehilce over the maximum fuel capacity of " + ex.MaxValue);
            }
            catch(WrongFuelException ex)
            {
                Console.WriteLine("Cannot fuel vehicle with {0} fuel type instead of {1}", ex.WrongFuel, ex.Fuel);
            }
        }
        private void GetFuelTypeFromUser(out GarageLogic.eFuelType o_FuelType)
        {
            bool v_ValidInput = false;
            int userChoice = 0;

            Console.Clear();
            Console.WriteLine("Please choose your vehicle's fuel type:");
            Console.WriteLine("1. Octan95");
            Console.WriteLine("2. Octan96");
            Console.WriteLine("3. Octan98");
            Console.WriteLine("4. Soler");
            while(v_ValidInput == false)
            {
                try
                {
                    v_ValidInput = GetValidIntFromUserInRange(out userChoice, 1, 4);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The choice number should be between " + ex.MinValue + " to " + ex.MaxValue);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            o_FuelType = (GarageLogic.eFuelType)userChoice;
        }

        private void GetAmountOfFuelToAddFromUser(out float o_FuelToAdd)
        {
            float capacityInput = 0;
            bool v_ValidInput = false;

            Console.WriteLine(" Enter how much fuel you want to add:");
            while(v_ValidInput == false)
            {
                try
                {
                    v_ValidInput = GetValidFloatFromUserInRange(out capacityInput, 0, float.MaxValue);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Error: Please enter a floating point number");
                }
                catch(ValueOutOfRangeException)
                {
                    Console.WriteLine("Error: Please enter a positive number");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }
            o_FuelToAdd = capacityInput;
        }

        private void RechargeVehicle()
        {
            string licenseNumber;
            bool v_ValidInput = false;

            Console.WriteLine("Please provide vehicle license.");
            licenseNumber = Console.ReadLine();
            GetBatteryMinutesToAddFromUser(out float batteryTimeToAdd);
            while(v_ValidInput == false)
            {
                try
                {
                    m_Garage.Recharge(licenseNumber, batteryTimeToAdd);
                    Console.WriteLine("Vehicle charged successfuly");
                    v_ValidInput = true;
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("License Number does not exist in the garage");
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("The vehicle has no Battery");
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Cannot charge battery over " + ex.MaxValue);
                }
            }
        }

        private void GetBatteryMinutesToAddFromUser(out float o_TimeToAdd)
        {
            float timeInput = 0;
            bool v_ValidInput = false;

            Console.WriteLine("Enter how much time you want to add to the battery (hours):");
            while(v_ValidInput == false)
            {
                try
                {
                    v_ValidInput = GetValidFloatFromUserInRange(out timeInput, 0, float.MaxValue);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter a float number");
                }
                catch(ValueOutOfRangeException)
                {
                    Console.WriteLine("Please enter a positive number");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unknown error: " + ex.Message);
                }
            } 

            o_TimeToAdd = timeInput;
        }

        private void DisplayVehicleInfo()
        {
            string licensePlate;

            Console.WriteLine("Please provide the license plate.");
            licensePlate = Console.ReadLine();
            try
            {
                m_Garage.DisplayVehicleInformation(licensePlate);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
