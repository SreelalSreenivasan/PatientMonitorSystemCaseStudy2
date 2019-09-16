using System;
using PatientDataParameterValidatorContractsLib;

namespace PatientSpo2ValidatorLib
{
    public class PatientSpo2Validator : IPatientDataParameterValidator
    {
        private const decimal Spo2Max = 100;
        private const decimal Spo2Min = 91;
        /// <summary>
        /// validates the given Spo2
        /// </summary>
        /// <typeparam name="TDecimal"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool ParameterValidate<TDecimal>(TDecimal parameter)
        {
            decimal spo2 = Convert.ToDecimal(parameter);
            if (spo2 < Spo2Min || spo2 > Spo2Max)
                return true;
            return false;
            
        }
    }
}
