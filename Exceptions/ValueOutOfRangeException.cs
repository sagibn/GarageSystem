using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;
        private const string m_ValueOutOfRangeExceptionMessage = "The value value must be between {0} and {1}.";

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) 
            : base(string.Format(m_ValueOutOfRangeExceptionMessage, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
