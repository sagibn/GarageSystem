using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic;
using System;
using System.Collections.Generic;


namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        private Garage m_Garage;

        public UserInterface()
        {
            m_Garage = new Garage();
        }
        public void Run()
        {
            while(true)
            {
                try
                {
                    mainMenu();
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void mainMenu()
        {
            Dictionary<int, string> services = m_Garage.Services;
            string userInput;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Ofir&Sagi's garage, here are all of our services:");
                foreach (var kvp in services)
                {
                    Console.WriteLine(kvp.Value);
                }

                Console.WriteLine("Please choose the desired service:");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        addNewVehicleToGarage();
                        break;
                    case "2":
                        showVehiclesInGarage();
                        break;
                    case "3":
                        changeVehicleStatus();
                        break;
                    case "4":
                        inflateTiresToMax();
                        break;
                    case "5":
                        refuelVehicle();
                        break;
                    case "6":
                        rechargeVehicle();
                        break;
                    case "7":
                        displayVehicleInfo();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Wrong input. Please try again.");
                        break;
                }

                Console.WriteLine("Please press any key to return to the menu.");
                Console.ReadKey();
            }
        }

        private void addNewVehicleToGarage()
        {
            string licenseNumber, ownerName, PhoneNumber;
            VehicleProperties vehicleProperties;
            Garage.eVehicleTypes vehicleType;

            Console.Clear();
            Console.WriteLine("Please provide the license number of the car you wish to add to the garage.");
            licenseNumber = Console.ReadLine();
            if(m_Garage.CheckIfVehicleExists(licenseNumber))
            {
                Console.WriteLine("Vehicle already exists in the garage.");
            }
            else
            {
                getInfoFromCustomer(licenseNumber, out vehicleType, out vehicleProperties
                    , out ownerName, out PhoneNumber);
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

        private void getInfoFromCustomer(string i_LicensePlate, out Garage.eVehicleTypes io_VehicleType,
            out VehicleProperties io_VehicleProperties, out string io_OwnerName, out string io_PhoneNumber)
        {
            while(true)
            {
                try
                {
                    getOwnerPhoneAndName(out io_PhoneNumber, out io_OwnerName);
                    break;
                }
                catch(FormatException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

            io_VehicleType = getVehicleType();
            while(true)
            {
                try
                {
                    if(io_VehicleType == Garage.eVehicleTypes.ElectricCar 
                        || io_VehicleType == Garage.eVehicleTypes.FuelCar)
                    {
                        io_VehicleProperties = getCarProperties(i_LicensePlate);
                    }
                    else if(io_VehicleType == Garage.eVehicleTypes.FuelMotorcycle 
                        || io_VehicleType == Garage.eVehicleTypes.ElectricMotorcycle)
                    {
                        io_VehicleProperties = getMotorcycleProperties(i_LicensePlate);
                    }
                    else if(io_VehicleType == Garage.eVehicleTypes.FuelTruck)
                    {
                        io_VehicleProperties = getTruckProperties(i_LicensePlate);
                    }
                    else
                    {
                        io_VehicleProperties = null;
                    }

                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private Garage.eVehicleTypes getVehicleType()
        {
            string userInput;
            Garage.eVehicleTypes? vehicleType = null;

            Console.WriteLine("Please select the type of the car:");
            Console.WriteLine("For fuel car please press 1.");
            Console.WriteLine("For electric car please press 2.");
            Console.WriteLine("For fuel motorcycle please press 3.");
            Console.WriteLine("For electric motorcycle please press 4.");
            Console.WriteLine("For truck please press 5.");
            userInput = Console.ReadLine();
            while (!vehicleType.HasValue)
            {
                switch (userInput)
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
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }

            return vehicleType.Value;
        }

        private void getOwnerPhoneAndName(out string io_OwnerPhone, out string io_OwnerName)
        {
            Console.WriteLine("Please provide the owner's name:");
            io_OwnerName = Console.ReadLine();
            if(!validateCustomerName(io_OwnerName))
            {
                throw new FormatException("Invalid customer name, please provide a valid name.");
            }

            Console.WriteLine("Please provide owner's Phone - a 10 digit IL valid number.");
            io_OwnerPhone = Console.ReadLine();
            if(!validateCustomerPhoneNumber(io_OwnerPhone))
            {
                throw new FormatException("Please provide a valid phone number.");
            }
        }

        private bool validateCustomerPhoneNumber(string i_CustomerPhoneNumber)
        {
            bool checkingPhoneNumber = true;

            if(i_CustomerPhoneNumber.Length != 10)
            {
                checkingPhoneNumber = false;
            }
            else
            {
                foreach(Char digit in i_CustomerPhoneNumber)
                {
                    if(!(Char.IsDigit(digit)))
                    {
                        checkingPhoneNumber = false;
                    }
                }
            }

            return checkingPhoneNumber;
        }
        private bool validateCustomerName(string i_CustomerName)
        {
            bool checkingName = true;

            foreach(Char letter in i_CustomerName)
            {
                    checkingName = !(letter != ' ' && !(Char.IsLetter(letter)));
            }

            return checkingName;
        }

        private CarProperties getCarProperties(string i_LicensePlate)
        {
            eCarColor carColor;
            string modelName, wheelManufactureName;
            float wheelCurrAirPressure, currEnergy;

            Console.WriteLine("Please provide the number of doors:");
            if(!int.TryParse(Console.ReadLine(), out int numOfDoors))
            {
                throw new FormatException("Number of doors must be an int.");
            }

            if(numOfDoors < 2 || numOfDoors > 5)
            {
                throw new ValueOutOfRangeException(2, 5, numOfDoors);
            }

            getBasicInfoAboutVehicle(out modelName, out wheelManufactureName, out wheelCurrAirPressure
                , out currEnergy);

            carColor = getCarColor();

            return new CarProperties(numOfDoors, carColor, modelName, i_LicensePlate, wheelManufactureName, wheelCurrAirPressure, currEnergy);
        }
        private eCarColor getCarColor()
        {
            string userInput;
            eCarColor carColor;

            while(true)
            {
                Console.WriteLine("For the color white press 1.");
                Console.WriteLine("For the color black press 2.");
                Console.WriteLine("For the color red press 3.");
                Console.WriteLine("For the color yellow press 4.");
                userInput = Console.ReadLine();

                if(userInput == "1")
                {
                    carColor = eCarColor.White;
                }
                else if(userInput == "2")
                {
                    carColor = eCarColor.Black;
                }
                else if(userInput == "3")
                {
                    carColor = eCarColor.Red;
                }
                else if(userInput == "4")
                {
                    carColor = eCarColor.Yellow;
                }
                else
                {
                    Console.WriteLine("Invlaid Input.");
                    continue;
                }

                return carColor;
            }
        }

        private MotorcycleProperties getMotorcycleProperties(string i_LicensePlate)
        {
            Motorcycle.eLicenseType licenseType;
            int engineCapacity;
            float wheelCurrAirPressure, currEnergy;
            string modelName, wheelManufactureName;

            getBasicInfoAboutVehicle(out modelName, out wheelManufactureName, out wheelCurrAirPressure
                , out currEnergy);

            licenseType = getLicenseType();
            while(true)
            {
                try
                {
                    engineCapacity = getEngineCap();
                    break;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return new MotorcycleProperties(licenseType, engineCapacity, modelName, i_LicensePlate, wheelManufactureName, wheelCurrAirPressure, currEnergy);
        }

        private bool validateStringContainsOnlyAlphbet(string i_StringToCheck)
        {
            bool validString = true;

            foreach(char c in i_StringToCheck)
            {
                if(c < 'a' || 'z' < c && c < 'A' || 'Z' < c)
                {
                    validString = false;
                }
            }

            return validString;
        }

        private Motorcycle.eLicenseType getLicenseType()
        {
            string input;
            Motorcycle.eLicenseType licenseType;

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
                    licenseType = Motorcycle.eLicenseType.A1;
                }
                else if(input == "2")
                {
                    licenseType = Motorcycle.eLicenseType.A2;
                }
                else if(input == "3")
                {
                    licenseType = Motorcycle.eLicenseType.AA;
                }
                else if(input == "4")
                {
                    licenseType = Motorcycle.eLicenseType.B1;
                }
                else
                {
                    Console.WriteLine("Please provide a valid license type");
                    continue;
                }

                return licenseType;
            }
        }

        private int getEngineCap()
        {

            Console.WriteLine("Please provide the engine capacity.");

            if(!int.TryParse(Console.ReadLine(), out int engineCap))
            {
                throw new FormatException("Engine capacity must be an int.");
            }

            return engineCap;
        }

        private TruckProperties getTruckProperties(string i_LicensePlate)
        {
            float cargoVolume, wheelCurrAirPressure, currEnergy;
            string modelName, wheelManufactureName;

            getBasicInfoAboutVehicle(out modelName, out wheelManufactureName, out wheelCurrAirPressure
                , out currEnergy);

            containsHazardElements(out bool hazardElements);
            while(true)
            {
                try
                {
                    getCargoVolume(out cargoVolume);
                    break;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return new TruckProperties(hazardElements, cargoVolume, modelName, i_LicensePlate, wheelManufactureName, wheelCurrAirPressure, currEnergy);
        }

        private void getBasicInfoAboutVehicle(out string io_ModelName, out string io_WheelManufactureName,
            out float io_WheelCurrAirPressure, out float io_CurrEnerg)
        {
            string userInput;

            Console.WriteLine("Please provide the model name:");
            io_ModelName = Console.ReadLine();
            if(!validateStringContainsOnlyAlphbet(io_ModelName))
            {
                throw new ArgumentException("Model name must be a Alphbet valid name.");
            }

            Console.WriteLine("Please provide the wheel manufacture name:");
            io_WheelManufactureName = Console.ReadLine();
            if(!validateStringContainsOnlyAlphbet(io_WheelManufactureName))
            {
                throw new ArgumentException("Wheel manufacture name must be a Alphbet valid name.");
            }

            Console.WriteLine("Please provide the wheel current air pressure:");
            userInput = Console.ReadLine();
            if(!float.TryParse(userInput, out io_WheelCurrAirPressure))
            {
                throw new FormatException("Air pressure must be a floating number.");
            }

            Console.WriteLine("Please provide the current energy(amount of fuel / battery time):");
            userInput = Console.ReadLine();
            if(!float.TryParse(userInput, out io_CurrEnerg))
            {
                throw new FormatException("Energy must be a float.");
            }
        }
        private void containsHazardElements(out bool io_HazardElements)
        {
            string input;

            while(true)
            {
                Console.WriteLine("Press 1 if the cargo has hazard elements or 0 if it doesn't.");
                input = Console.ReadLine();
                if(input == "1")
                {
                    io_HazardElements = true;
                    return;
                }
                else if(input == "0")
                {
                    io_HazardElements = false;
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input please try again.");
                }
            }
        }

        private void getCargoVolume(out float io_CargoVolume)
        {
            Console.WriteLine("Please provide the cargo volume.");
            if(!float.TryParse(Console.ReadLine(), out io_CargoVolume))
            {
                throw new FormatException("Cargo volume must be a int.");
            }
        }
        private void showVehiclesInGarage()
        {
            string userInput;
            eVehicleStatus? vehicleStatus = null;
            bool validInput = false;
            List<string> listOfLicenseNumbers;

            Console.Clear();
            while (!validInput)
            {
                Console.WriteLine("If you want to get all the vehicles that are in repair, please press 1.");
                Console.WriteLine("If you want to get all the vehicles that are fixed, please press 2.");
                Console.WriteLine("If you want to get all the vehicles that have been paid, please press 3.");
                Console.WriteLine("If you want to get all the vehicles in the garage, please press 4.");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        vehicleStatus = eVehicleStatus.InRepair;
                        validInput = true;
                        break;
                    case "2":
                        vehicleStatus = eVehicleStatus.Fixed;
                        validInput = true;
                        break;
                    case "3":
                        vehicleStatus = eVehicleStatus.Paid;
                        validInput = true;
                        break;
                    case "4":
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input please try again.");
                        break;
                }
            }

            listOfLicenseNumbers = m_Garage.FilterLicenseNumberByStatus(vehicleStatus);
            foreach(string licenseNum in listOfLicenseNumbers)
            {
                Console.WriteLine(licenseNum);
            }
        }

        private void changeVehicleStatus()
        {
            string licenseNumber;

            Console.Clear();
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
            getVehicleStatusFromUser(out eVehicleStatus newVehicleStatus);
            try
            {
                m_Garage.ChangeVehicleStatus(licenseNumber, newVehicleStatus);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getVehicleStatusFromUser(out eVehicleStatus io_VehicleStatus)
        {
            string userChoice;
            bool validInput = false;
            eVehicleStatus? vehicleStatus = null;

            Console.WriteLine("Please choose vehicle status:");
            Console.WriteLine("1.In repair");
            Console.WriteLine("2.Fixed");
            Console.WriteLine("3.Paid");
            userChoice = Console.ReadLine();

            while(!validInput)
            {
                if(userChoice == "1")
                {
                    vehicleStatus = eVehicleStatus.InRepair;
                    validInput = true;
                }
                else if(userChoice == "2")
                {
                    vehicleStatus = eVehicleStatus.Fixed;
                    validInput = true;
                }
                else if(userChoice == "3")
                {
                    vehicleStatus = eVehicleStatus.Paid;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input please try again.");
                }
            }

            io_VehicleStatus = vehicleStatus.Value;
        }

        private bool getValidIntFromUserInRange(out int io_UserInput, int i_MinValue, int i_MaxValue)
        {
            if(int.TryParse(Console.ReadLine(), out io_UserInput) == false)
            {
                throw new FormatException();
            }

            if(io_UserInput < i_MinValue || io_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue, io_UserInput);
            }

            return true;
        }

        private bool getValidFloatFromUserInRange(out float io_UserInput, float i_MinValue, float i_MaxValue)
        {
            if(float.TryParse(Console.ReadLine(), out io_UserInput) == false)
            {
                throw new FormatException();
            }

            if(io_UserInput < i_MinValue || io_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue, io_UserInput);
            }

            return true;
        }

        private void inflateTiresToMax()
        {
            string licenseNumber;

            Console.Clear();
            try
            {
                Console.WriteLine("Please provide the license number.");
                licenseNumber = Console.ReadLine();
                m_Garage.InflateTiresToMax(licenseNumber);
                Console.WriteLine("Vehicles wheels inflated to max successfuly.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void refuelVehicle()
        {
            string licenseNumber;

            Console.Clear();
            Console.WriteLine("Please provide vehicle license.");
            licenseNumber = Console.ReadLine();
            getFuelTypeFromUser(out eFuelType fuelType);
            getAmountOfFuelToAddFromUser(out float fuelToAdd);
            
            try
            {
                m_Garage.Refuel(licenseNumber, fuelType, fuelToAdd);
                Console.WriteLine("The vehicle was successfully refueled.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getFuelTypeFromUser(out eFuelType io_FuelType)
        {
            bool validInput = false;
            string userChoice;
            eFuelType? fuelType = null;

            Console.Clear();
            Console.WriteLine("Please choose your vehicle's fuel type:");
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan95");
            Console.WriteLine("3. Octan96");
            Console.WriteLine("4. Octan98");
            userChoice = Console.ReadLine();
            while(!validInput)
            {
                if(userChoice == "1")
                {
                    fuelType = eFuelType.Soler;
                    validInput = true;
                }
                else if(userChoice == "2")
                {
                    fuelType = eFuelType.Octan95;
                    validInput = true;
                }
                else if(userChoice == "3")
                {
                    fuelType = eFuelType.Octan96;
                    validInput = true;
                }
                else if(userChoice == "4")
                {
                    fuelType = eFuelType.Octan98;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }

            io_FuelType = fuelType.Value;
        }

        private void getAmountOfFuelToAddFromUser(out float io_FuelToAdd)
        {
            float capacityInput = 0;
            bool validInput = false;

            Console.WriteLine("Enter how much fuel you want to add:");
            while(!validInput)
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out capacityInput, 0, float.MaxValue);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            io_FuelToAdd = capacityInput;
        }

        private void rechargeVehicle()
        {
            string licenseNumber;

            Console.Clear();
            Console.WriteLine("Please provide vehicle license.");
            licenseNumber = Console.ReadLine();
            getBatteryMinutesToAddFromUser(out float batteryTimeToAdd);
            try
            {
                m_Garage.Recharge(licenseNumber, batteryTimeToAdd);
                Console.WriteLine("Vehicle charged successfuly");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getBatteryMinutesToAddFromUser(out float io_TimeToAdd)
        {
            float timeInput = 0;
            bool validInput = false;

            Console.WriteLine("Enter how much time you want to add to the battery (hours):");
            while(!validInput)
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out timeInput, 0, float.MaxValue);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            io_TimeToAdd = timeInput;
        }

        private void displayVehicleInfo()
        {
            string licensePlate;

            Console.Clear();
            Console.WriteLine("Please provide the license plate.");
            licensePlate = Console.ReadLine();
            try
            {
                m_Garage.DisplayVehicleInformation(licensePlate);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
