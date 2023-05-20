using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleGenerator
    {
        public Vehicle GenerateVehicle(Garage.eVehicleTypes i_VehicleType, VehicleProperties i_VehicleProperties)
        {
            Vehicle vehicle = null;

            if(i_VehicleType == Garage.eVehicleTypes.FuelCar && (i_VehicleProperties is CarProperties fuelCarProperties))
            {
                EnergySource fuelEngine = new FuelEngine(eFuelType.Octan95, i_VehicleProperties.CurrEnergy, 46f);
                vehicle = new Car(fuelCarProperties, fuelEngine);
            }
            else if (i_VehicleType == Garage.eVehicleTypes.ElectricCar && (i_VehicleProperties is CarProperties electricCarProperties))
            {
                EnergySource electricEngine = new ElectricEngine(i_VehicleProperties.CurrEnergy, 5.2f);
                vehicle = new Car(electricCarProperties, electricEngine);
            }
            else if (i_VehicleType == Garage.eVehicleTypes.FuelMotorcycle && (i_VehicleProperties is MotorcycleProperties fuelMotorcycleProperties))
            {
                EnergySource fuelEngine = new FuelEngine(eFuelType.Octan98,i_VehicleProperties.CurrEnergy, 6.4f);
                vehicle = new Motorcycle(fuelMotorcycleProperties, fuelEngine);
            }
            else if (i_VehicleType == Garage.eVehicleTypes.ElectricMotorcycle && (i_VehicleProperties is MotorcycleProperties electricMotorcycleProperties))
            {
                EnergySource electricEngine = new ElectricEngine(i_VehicleProperties.CurrEnergy, 2.6f);
                vehicle = new Motorcycle(electricMotorcycleProperties, electricEngine);
            }
            else if (i_VehicleType == Garage.eVehicleTypes.FuelTruck && (i_VehicleProperties is TruckProperties truckProperties))
            {
                EnergySource fuelEngine = new FuelEngine(eFuelType.Soler, i_VehicleProperties.CurrEnergy, 135f);
                vehicle = new Truck(truckProperties, fuelEngine);
            }

            return vehicle;
        }
    }
}
