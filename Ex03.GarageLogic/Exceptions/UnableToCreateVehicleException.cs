using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Exceptions
{
    class UnableToCreateVehicleException : Exception
    {
        public UnableToCreateVehicleException(string i_ErrorMsg) : base(i_ErrorMsg)
        {
        }
    }
}
