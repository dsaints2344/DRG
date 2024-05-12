using AutoMapper;
using DRG.Application.Core;
using DRG.Application.DTOs;
using DRG.Domain;
using DRG.Persistence;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DRG.Application.APRDRG
{
    public class APRDRG
    {
        private string _filePath {  get; set; }

        public APRDRG(string filePath)
        {
            _filePath = filePath;
        }

        public void ProcessFile(string version) {

            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet pricingSheet;
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

            if (version == "36")
            {
                
                List<APRDRGV36DTO> v36PricingList = new List<APRDRGV36DTO>();
                IQueryable<APRDRGV36DTO> pricingEnumerable = v36PricingList.AsQueryable();

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
                    pricingSheet = workbook.GetSheetAt(3);

                    for (int row = 4; row <= pricingSheet.LastRowNum; row++)
                    {
                        if (pricingSheet.GetRow(row) != null)
                        {
                            APRDRGV36DTO aprV36Dto = new APRDRGV36DTO()
                            {
                                APRDRG = pricingSheet.GetRow(row).GetCell(0).StringCellValue,
                                SOIScore = int.Parse(pricingSheet.GetRow(row).GetCell(1).StringCellValue),
                                CombinedSOI = pricingSheet.GetRow(row).GetCell(2).StringCellValue,
                                Description = pricingSheet.GetRow(row).GetCell(3).StringCellValue,
                                V36RelativeWeight = pricingSheet.GetRow(row).GetCell(4).CellType == CellType.Numeric ? (decimal?)pricingSheet.GetRow(row).GetCell(4).NumericCellValue : 0,
                                MLOS = pricingSheet.GetRow(row).GetCell(5).CellType == CellType.Numeric ? (double?)pricingSheet.GetRow(row).GetCell(5).NumericCellValue : 0,
                                DayOutlierThreshold = (pricingSheet.GetRow(row).GetCell(6).CellType == CellType.Numeric ? (int?)pricingSheet.GetRow(row).GetCell(6).NumericCellValue : 0)
                            };
                            v36PricingList.Add(aprV36Dto);
                        }
                    }

                    using (var context = new DataContext())
                    {
                        var mappedRatings = mapper.ProjectTo<APRDRGV36>(pricingEnumerable).ToList();

                        var existingEntries = context.APRDRGV38s.Any();
                        if (existingEntries)
                        {
                            Console.WriteLine($"DRG Weigths V{version} already exists");
                        }

                        else
                        {
                            context.APRDRGV36s.AddRange(mappedRatings);
                            context.SaveChanges();
                            Console.WriteLine($"Save changes for DRG Weigths V{version}");
                        }

                    }

               }
                
            }

            else 
            {
                List<APRDRGV38DTO> v38PricingList = new List<APRDRGV38DTO>();
                IQueryable<APRDRGV38DTO> pricingEnumerable = v38PricingList.AsQueryable();

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
                    pricingSheet = workbook.GetSheetAt(4);

                    for (int row = 4; row <= pricingSheet.LastRowNum; row++)
                    {
                        if (pricingSheet.GetRow(row) != null)
                        {
                            APRDRGV38DTO aprV38Dto = new APRDRGV38DTO()
                            {
                                APRDRG = pricingSheet.GetRow(row).GetCell(0).CellType == CellType.String ? pricingSheet.GetRow(row).GetCell(0).StringCellValue : pricingSheet.GetRow(row).GetCell(0).NumericCellValue < 100 ? pricingSheet.GetRow(row).GetCell(0).NumericCellValue.ToString().PadLeft(3, '0') : pricingSheet.GetRow(row).GetCell(0).NumericCellValue.ToString(),
                                SOIScore =  (pricingSheet.GetRow(row).GetCell(1).CellType == CellType.String ? int.Parse(pricingSheet.GetRow(row).GetCell(1).StringCellValue) : (int)pricingSheet.GetRow(row).GetCell(1).NumericCellValue),
                                CombinedSOI = pricingSheet.GetRow(row).GetCell(2).CellType == CellType.String ? pricingSheet.GetRow(row).GetCell(2).StringCellValue : pricingSheet.GetRow(row).GetCell(2).NumericCellValue.ToString(),
                                Description = pricingSheet.GetRow(row).GetCell(3).StringCellValue,
                                V38RelativeWeight = pricingSheet.GetRow(row).GetCell(4).CellType == CellType.Numeric ? (decimal?)pricingSheet.GetRow(row).GetCell(4).NumericCellValue : 0,
                                MLOS = pricingSheet.GetRow(row).GetCell(5).CellType == CellType.Numeric ? (double?)pricingSheet.GetRow(row).GetCell(5).NumericCellValue : 0,
                                DayOutlierThreshold = (pricingSheet.GetRow(row).GetCell(6).CellType == CellType.Numeric ? (int?)pricingSheet.GetRow(row).GetCell(6).NumericCellValue : 0)
                            };
                            v38PricingList.Add(aprV38Dto);
                        }
                    }

                    using (var context = new DataContext())
                    {
                        var mappedRatings = mapper.ProjectTo<APRDRGV38>(pricingEnumerable).ToList();

                        var existingEntries = context.APRDRGV38s.Any();
                        if (existingEntries)
                        {
                            Console.WriteLine($"DRG Weigths V{version} already exists");
                        }
                        
                        else
                        {
                            context.APRDRGV38s.AddRange(mappedRatings);
                            context.SaveChanges();

                            Console.WriteLine($"Save changes for DRG Weigths V{version}");
                        }

                    }
                }
            }
        }
    }
}
