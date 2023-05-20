using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InRepair,
        Fixed,
        Paid
    }
    public class CarDetails
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public CarDetails(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get 
            {
                return m_OwnerName; 
            }
        }

        public string PhoneNumber
        {
            get 
            {
                return m_PhoneNumber;
            }
        }

        public Vehicle Vehicle
        {
            get 
            { 
                return m_Vehicle; 
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get 
            {
                return m_VehicleStatus; 
            }
            set 
            {
                m_VehicleStatus = value; 
            }
        }

        public override string ToString()
        {
            string data = string.Format(@"Owner name:
{1}
Vehical status: {2}{3}",
            m_OwnerName, m_Vehicle.GetVehicleData(), m_VehicleStatus, Environment.NewLine);

            return data;
        }
    }
}
