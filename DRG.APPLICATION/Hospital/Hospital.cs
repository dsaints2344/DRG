using AutoMapper;
using DRG.Application.Core;
using DRG.Application.DTOs;
using DRG.Persistence;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace DRG.Application.Hospital
{
    

    public class Hospital
    {
        private string _filePath { get; set; }

        public Hospital(string filePath)
        {
                _filePath = filePath;
        }

        public void ProcessFile()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet hospitalAndRatesSheet;
            List<HospitalDTO> hospitalDTOs = new List<HospitalDTO>();
            IQueryable<HospitalDTO> hospitalDTOsEnumerables = hospitalDTOs.AsQueryable();

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

            if (workbook != null)
            {
                hospitalAndRatesSheet = workbook.GetSheetAt(5);

                for (int row = 1; row <= hospitalAndRatesSheet.LastRowNum; row++)
                {
                    if (hospitalAndRatesSheet.GetRow(row) != null)
                    {
                        var hospitalDTO = new HospitalDTO()
                        {
                            HospitalNPI = hospitalAndRatesSheet.GetRow(row).GetCell(0).NumericCellValue.ToString(),
                            HospitalName = hospitalAndRatesSheet.GetRow(row).GetCell(4).StringCellValue,
                            HospitalPhysicalCity = hospitalAndRatesSheet.GetRow(row).GetCell(5).StringCellValue,
                            HospitalPhysicalStreetAddress = hospitalAndRatesSheet.GetRow(row).GetCell(6).StringCellValue,
                            HospitalClass = hospitalAndRatesSheet.GetRow(row).GetCell(7).StringCellValue.ToUpper(),
                        };

                        if (hospitalDTOs.Where(h => h.HospitalNPI == hospitalDTO.HospitalNPI).Count() == 0)
                        {
                            hospitalDTOs.Add(hospitalDTO);
                        }
                    }
                    
                }

                using (var context = new DataContext())
                {
                    var mappedHospitals = mapper.ProjectTo<Domain.Hospital>(hospitalDTOsEnumerables).ToList();

                    var existingEntries = context.Hospitals.Any();
                    if (existingEntries)
                    {
                        Console.WriteLine("Hospital entries already exist");
                    }

                    else
                    {
                        context.Hospitals.AddRange(mappedHospitals);
                        context.SaveChanges();
                        Console.WriteLine($"Saved changes Hospital entries");
                    }

                }
            }
        }
    }
}
