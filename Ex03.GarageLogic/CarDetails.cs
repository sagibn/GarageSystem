using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InWork,
        Fixed,
        Paid
    }
    public class CarDetails
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_Status;

        public CarDetails(string i_OwnerName, string i_PhoneNumber, eVehicleStatus i_Status, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Status = i_Status;
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

        public eVehicleStatus Status
        {
            get 
            {
                return m_Status; 
            }
            set 
            {
                m_Status = value; 
            }
        }
    }
}
