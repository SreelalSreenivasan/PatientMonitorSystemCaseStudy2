﻿using System;
using PatientDataParameterValidatorContractsLib;

namespace PatientTemperatureValidatorLib
{
    public class PatientTemperatureValidator : IPatientDataParameterValidator
    {
        private const double TempMax = 99.0;
        private const double TempMin = 97.0;
        /// <summary>
        /// validates the given Temperature
        /// </summary>
        /// <typeparam name="TDouble"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool ParameterValidate<TDouble>(TDouble parameter)
        {
            double temperature = Convert.ToDouble(parameter);
            if (temperature < TempMin || temperature > TempMax)
            {
                return true;
            }
            return false;
            
        }
    }
}
