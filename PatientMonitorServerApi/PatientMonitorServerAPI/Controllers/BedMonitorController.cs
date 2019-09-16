using System.Collections.Generic;
using System.IO;
using JsonFormatValidatorLib;
using JsonPatientDataExtractorLib;
using Microsoft.AspNetCore.Mvc;
using PatientDataModule;
using PatientMonitorServerAPI.Helpers;
using PatientPulseRateValidatorLib;
using PatientSpo2ValidatorLib;
using PatientTemperatureValidatorLib;

namespace PatientMonitorServerAPI.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class BedMonitorController : ControllerBase
    {
        
        // GET: api/BedMonitor
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            var line = GetPatientId();
            return line;
        }

        [HttpGet]
        [Route("api/[controller]/discharge")]
        public ActionResult<string> GetDischargeInformation()
        {
            
            return Helper.patientDischarged;
        }

        private static List<string> GetPatientId()
        {
            List<string> patientList = new List<string>();
            Given_NewMethod(patientList);

            return patientList;
        }

        

        [HttpPost]
        public ActionResult<string[]> Post([FromBody] string value)
        {
            return Given_ActionResult(value);
        }

        private static ActionResult<string[]> Given_ActionResult(string value)
        {
            Helper.PatientDataFormatValidator = new JsonFormatValidator();
            Helper.PatientDataExtractor = new JsonPatientDataExtractor();
            Helper.Spo2ParameterValidator = new PatientSpo2Validator();
            Helper.PulseRateParameterValidator = new PatientPulseRateValidator();
            Helper.TemperatureParameterValidator = new PatientTemperatureValidator();

            if (Helper.PatientDataFormatValidator.IsValidFormat(value))
            {
                PatientData patientData = Helper.PatientDataExtractor.PatientDataExtractor(value);
                if (Helper.Spo2ParameterValidator.ParameterValidate(patientData.Spo2))
                {
                    Helper.Result[0] = "Abnormal Spo2";
                }

                if (Helper.PulseRateParameterValidator.ParameterValidate(patientData.PulseRate))
                {
                    Helper.Result[1] = "Abnormal PulseRate";
                }

                if (Helper.TemperatureParameterValidator.ParameterValidate(patientData.Temperature))
                {
                    Helper.Result[2] = "Abnormal Temperature";
                }


                return Helper.Result;
            }
            else
            {
                return Helper.Result;
            }
        }
        private static void Given_NewMethod(List<string> patientList)
        {
            using (StreamReader sr =
                new StreamReader(@Path.GetFullPath(Directory.GetCurrentDirectory() + @"\serverdata.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    patientList.Add(line);
                }

                // Read the stream to a string, and append to list of patientId.
            }
        }

    }
}
