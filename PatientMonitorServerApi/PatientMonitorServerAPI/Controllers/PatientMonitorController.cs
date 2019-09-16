using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PatientMonitorServerAPI.Helpers;

namespace PatientMonitorServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMonitorController : ControllerBase
    {
        // GET: api/PatientMonitor
        [HttpGet]
        public ActionResult<string[]> Get()
        {
            return Helper.Result;
        }

        // GET: api/PatientMonitor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PatientMonitor
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return Given_CannotFindRequiredPatientidToDischarge(value);
        }

        private static string Given_CannotFindRequiredPatientidToDischarge(string value)
        {
            string patId = value;
            if (UpdatePatientIdDetails(patId))
                return "Patient Discharged successfully";
            else
            {
                return "Cannot find required PatientId to discharge";
            }
        }

        private static bool UpdatePatientIdDetails(string patId)
        {
            List<string> patientList = new List<string>();
            Helper.patientDischarged = patId;
            
            using (StreamReader sr =
                new StreamReader(Path.GetFullPath(Directory.GetCurrentDirectory() + @"\serverdata.txt")))
            {
                while (!sr.EndOfStream)
                    {
                        var ln = sr.ReadLine();
                        if (ln != patId)
                            patientList.Add(ln);
                    }
                
               
            }

            using (StreamWriter sw =
                    new StreamWriter(
                        Path.GetFullPath(Directory.GetCurrentDirectory() + @"\serverdata.txt")))
                {

                    foreach (var patientId in patientList)
                    {
                        sw.WriteLine(patientId);
                    }

                    
                    return true;
            }

            
        }
    }
}
