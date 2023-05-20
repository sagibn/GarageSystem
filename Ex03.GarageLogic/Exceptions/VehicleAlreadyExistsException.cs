using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    class VehicleAlreadyExistsException : Exception
    {
        private string m_LicenseNumber;
        private const string m_VehicleAlreadyExistsException =
            "Vehicle with the license number of {0} is already exists.";

        public VehicleAlreadyExistsException(string i_LicenseNumber)
            : base(string.Format(m_VehicleAlreadyExistsException, i_LicenseNumber))
        {
            m_LicenseNumber = i_LicenseNumber;
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }
    }
}
