using System;


namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;
        private const string m_ValueOutOfRangeExceptionMessage =
            "Trying to put {2}. The value must be between {0} and {1}.";

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_CurrValue) 
            : base(string.Format(m_ValueOutOfRangeExceptionMessage, i_MinValue, i_MaxValue, i_CurrValue))
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
    }
}
