using Newtonsoft.Json;
using PatientDataExtractorContractsLib;
using PatientDataModule;


namespace JsonPatientDataExtractorLib
{
    public class JsonPatientDataExtractor : IPatientDataExtractor
    {
        /// <summary>
        /// converts into PatientData Object by deserializing Json String
        /// </summary>
        /// <param name="patientData"></param>
        /// <returns></returns>
        public PatientData PatientDataExtractor(string patientData)
        {
            PatientData pd = JsonConvert.DeserializeObject<PatientData>(patientData);
            return pd;
        }
    }
}
