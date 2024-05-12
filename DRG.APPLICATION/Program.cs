
using DRG.Application.APRDRG;

internal class Program
{
    private static void Main(string[] args)
    {
        var pricingWorkbookPath = @"C:\Repos\DRG\DCM Dev Test Project\Price Sheet Calculation.xlsx";
        APRDRG aprdrgPricing = new APRDRG(pricingWorkbookPath, "38");
        aprdrgPricing.ProcessFile("38");

    }
}