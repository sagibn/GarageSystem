using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrEnergy;
        private float m_MaxEnergy;
        private float m_EnergyPercentage;

        public EnergySource(float i_CurrEnergy, float i_MaxEnergy)
        {
            if(i_MaxEnergy <= 0 || i_CurrEnergy <= 0)
            {
                throw new ArgumentException("The amount of energy cannot be an unnatural number.");
            }
            else if(i_CurrEnergy > i_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, i_MaxEnergy, i_CurrEnergy);
            }

            m_CurrEnergy = i_CurrEnergy;
            m_MaxEnergy = i_MaxEnergy;
            UpdateEnergyPercentage();
        }

        public float CurrEnergy
        {
            get
            {
                return m_CurrEnergy;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
        }

        public void AddEnergy(float i_EnergyToAdd)
        {
            if(m_CurrEnergy + i_EnergyToAdd <= m_MaxEnergy)
            {
                m_CurrEnergy += i_EnergyToAdd;
                UpdateEnergyPercentage();
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergy, m_CurrEnergy + i_EnergyToAdd);
            }
        }

        private void UpdateEnergyPercentage()
        {
            m_EnergyPercentage = (m_CurrEnergy / m_MaxEnergy) * 100.0f;
        }
    }
}
