
using DRG.Application.APRDRG;
using DRG.Application.Hospital;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        var pricingWorkbookPath = @"C:\Repos\DRG\DCM Dev Test Project\Price Sheet Calculation.xlsx";
        //APRDRG aprdrgPricing = new APRDRG(pricingWorkbookPath);
        //aprdrgPricing.ProcessFile("36");
        //aprdrgPricing.ProcessFile("38");

        //Hospital hospitals = new Hospital(pricingWorkbookPath);
        //hospitals.ProcessFile();
        //HospitalRate hospitalRates = new HospitalRate(pricingWorkbookPath);
        //hospitalRates.ProcessFile();
        CHIRPHospital CHIRPHospital = new CHIRPHospital(pricingWorkbookPath);
        CHIRPHospital.ProcessFile();
    }
}