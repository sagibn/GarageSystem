

namespace Ex03.GarageLogic
{
    public class CarProperties : VehicleProperties
    {
        int m_NumOfDoors;
        eCarColor m_CarColor;

        public CarProperties(int i_NumOfDoors, eCarColor i_CarColor, string i_ModelName,
            string i_LicenseNumber, string i_WheelManufactureName, float i_WheelCurrAirPressure, float i_CurrEnergy)
            : base(i_ModelName, i_LicenseNumber, i_WheelManufactureName, i_WheelCurrAirPressure, 33.0f, i_CurrEnergy)
        {
            m_NumOfDoors = i_NumOfDoors;
            m_CarColor = i_CarColor;
        }

        public int NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }
    }
}
