using System;
using PatientDataFormatValidatorContractsLib;
using Newtonsoft.Json.Linq;

namespace JsonFormatValidatorLib
{
    public class JsonFormatValidator : IPatientDataFormatValidator
    {
        /// <summary>
        /// validates whether received string from client is Json String or not
        /// </summary>
        /// <param name="patData"></param>
        /// <returns></returns>
        
        public bool IsValidFormat(string patData)
        {
            try
            {
                JToken.Parse(patData);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }
    }
}
