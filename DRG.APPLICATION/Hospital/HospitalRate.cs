using AutoMapper;
using DRG.Application.Core;
using DRG.Application.DTOs;
using DRG.Persistence;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Globalization;

namespace DRG.Application.Hospital
{
    public class HospitalRate
    {
        private string _filePath { get; set; }

        public HospitalRate(string filePath)
        {
            _filePath = filePath;
        }

        public void ProcessFile()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet hospitalAndRatesSheet;
            List<HospitalRateDTO> hospitalRatesDTOs = new List<HospitalRateDTO>();
            IQueryable<HospitalRateDTO> hospitalRatesDTOsEnumerables = hospitalRatesDTOs.AsQueryable();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            using (FileStream file = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                if (file != null)
                {
                    workbook = new XSSFWorkbook(file);
                }
                else
                {
                    Console.WriteLine("File not found in path provided!");
                }
            }
            
            hospitalAndRatesSheet = workbook.GetSheetAt(5);

            for (int row = 1; row <= hospitalAndRatesSheet.LastRowNum; row++)
            {
                
                if (hospitalAndRatesSheet.GetRow(row) != null)
                {
                    // Console.WriteLine(hospitalAndRatesSheet.GetRow(row).GetCell(14).NumericCellValue);
                    var hospitalRateDto = new HospitalRateDTO()
                    {
                        NPI = hospitalAndRatesSheet.GetRow(row).GetCell(0).NumericCellValue.ToString(),
                        Month = DateTime.Parse(hospitalAndRatesSheet.GetRow(row).GetCell(1).StringCellValue, CultureInfo.InvariantCulture).Month,
                        Year = DateTime.Parse(hospitalAndRatesSheet.GetRow(row).GetCell(1).StringCellValue, CultureInfo.InvariantCulture).Year,
                        NPIMonthYear = hospitalAndRatesSheet.GetRow(row).GetCell(2).StringCellValue,
                        IPRate = (decimal)hospitalAndRatesSheet.GetRow(row).GetCell(3).NumericCellValue,
                        ProviderName = hospitalAndRatesSheet.GetRow(row).GetCell(4).StringCellValue,
                        SDA = hospitalAndRatesSheet.GetRow(row).GetCell(8).NumericCellValue.ToString(),
                        DeliverySDA = hospitalAndRatesSheet.GetRow(row).GetCell(9).NumericCellValue.ToString(),
                        PPRPPC = hospitalAndRatesSheet.GetRow(row).GetCell(10).NumericCellValue.ToString(),
                        Contract = hospitalAndRatesSheet.GetRow(row).GetCell(11).NumericCellValue.ToString(),
                        PercentageThreshold = (decimal)hospitalAndRatesSheet.GetRow(row).GetCell(12).NumericCellValue,
                        HHSCPublishDate = (DateTime)hospitalAndRatesSheet.GetRow(row).GetCell(13).DateCellValue!,
                        CHIRPRate = hospitalAndRatesSheet.GetRow(row).GetCell(14) != null ? 
                        (hospitalAndRatesSheet.GetRow(row).GetCell(14).CellType == CellType.Numeric ? (decimal)hospitalAndRatesSheet.GetRow(row).GetCell(14).NumericCellValue :
                         null) : null,
                    };

                    hospitalRatesDTOs.Add(hospitalRateDto);
                }
            }

            using (var context = new DataContext())
            {
                var mappedHospitalsRates = mapper.ProjectTo<Domain.HospitalRate>(hospitalRatesDTOsEnumerables).ToList();

                var existingEntries = context.HospitalRates.Any();
                if (existingEntries)
                {
                    Console.WriteLine("Hospital Rates entries already exist");
                }

                else
                {
                    context.HospitalRates.AddRange(mappedHospitalsRates);
                    context.SaveChanges();
                    Console.WriteLine($"Saved changes Hospital Rates entries");
                }

            }

        }
    }
}
