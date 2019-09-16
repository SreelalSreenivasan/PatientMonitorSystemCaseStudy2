using System;
using PatientDataParameterValidatorContractsLib;

namespace PatientPulseRateValidatorLib
{
    public class PatientPulseRateValidator : IPatientDataParameterValidator
    {
        private const decimal PulseRateMax = 100;
        private const decimal PulseRateMin = 60;
        /// <summary>
        /// validates the given PulseRate
        /// </summary>
        /// <typeparam name="TDecimal"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool ParameterValidate<TDecimal>(TDecimal parameter)
        {
            decimal pulseRate = Convert.ToDecimal(parameter);
            if (pulseRate < PulseRateMin || pulseRate > PulseRateMax)
            {
                return true;
            }
            return false;
            
        }
    }
}
