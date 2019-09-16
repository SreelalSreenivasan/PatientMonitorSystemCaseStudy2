@echo off
set "BAT_PATH=%~dp0"



@echo off


call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%

echo Executing batch file


devenv "%BAT_PATH%\PatientMonitorServerAPI.sln" /build Debug 
pause
#call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\MSTest.exe" /testcontainer:"%BAT_PATH%JsonFormatValidatorLib.Tests\bin\Debug\JsonFormatValidatorLib.Tests.dll" /test:Given_ValidJsonString_When_IsValidFormatInvoked_Expected_True /Test:Given_InvalidJsonString_When_IsValidFormatInvoked_Expected_False

MSTest /TestContainer:"%BAT_PATH%PatientSpo2ValidatorLib.Tests\bin\Debug\PatientSpo2ValidatorLib.Tests.dll" /Test:Given_ValidSpo2Value_When_PatientSpo2Validator_Invoked_FalseExpected /Test:Given_PositiveInvalidSpo2Value_When_PatientSpo2Validator_Invoked_TrueExpected
/Test:Given_NegativeInvalidSpo2Value_When_PatientSpo2Validator_Invoked_TrueExpected

mstest /TestContainer:"%BAT_PATH%PatientTemperatureValidatorLib.Tests\bin\Debug\PatientTemperatureValidatorLib.Tests.dll" /Test:Given_ValidTemperatureValue_When_PatientTemperatureValidator_Invoked_FalseExpected /Test:Given_PositiveInvalidTemperatureValue_When_PatientTemperatureValidator_Invoked_TrueExpected
/Test:Given_NegativeInvalidTemperatureValue_When_PatientTemperatureValidator_Invoked_TrueExpected

mstest /TestContainer:"%BAT_PATH%PatientPulseRateValidatorLib.Tests\bin\Debug\PatientPulseRateValidatorLib.Tests.dll" /Test:Given_ValidPulseRateValue_When_PatientPulseRateValidator_Invoked_FalseExpected /Test:Given_PositiveInvalidPulseRateValue_When_PatientPulseRateValidator_Invoked_TrueExpected
/Test:Given_NegativeInvalidPulseRateValue_When_PatientPulseRateValidator_Invoked_TrueExpected
 

pause
 
set "SIM_PATH=C:\Users\320052122\Downloads\simian-2.5.10.tar\simian-2.5.10\bin"

cd "%SIM_PATH%"

simian-2.5.10.exe "%BAT_PATH%\**\*.cs"  

pause

start "" http://localhost:59372/api/BedMonitor


pause