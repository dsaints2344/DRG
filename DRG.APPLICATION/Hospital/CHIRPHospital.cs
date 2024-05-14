using AutoMapper;
using DRG.Application.Core;
using DRG.Application.DTOs;
using DRG.Persistence;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRG.Application.Hospital
{
    public class CHIRPHospital
    {
        private string _filePath { get; set; }

        public CHIRPHospital(string filePath)
        {
            _filePath = filePath;
        }

        public void ProcessFile()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet CHIRPHospitalSheet;
            List<CHIRPHospitalDTO> CHIRPHospitalDTOs = new List<CHIRPHospitalDTO>();
            IQueryable<CHIRPHospitalDTO> CHIRPHospitalDTOsEnumerables = CHIRPHospitalDTOs.AsQueryable();

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

            CHIRPHospitalSheet = workbook.GetSheetAt(7);

            for (int row = 3; row <= CHIRPHospitalSheet.LastRowNum - 2 ; row++)
            {

                if (CHIRPHospitalSheet.GetRow(row) != null)
                {
                    Console.WriteLine((CHIRPHospitalSheet.GetRow(row).GetCell(6).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(5).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(6).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(6).StringCellValue)));
                    var CHIRPHospitalDTO = new CHIRPHospitalDTO()
                    {
                        CHIRPNPI = CHIRPHospitalSheet.GetRow(row).GetCell(1).CellType == CellType.Numeric ? CHIRPHospitalSheet.GetRow(row).GetCell(1).NumericCellValue.ToString() : CHIRPHospitalSheet.GetRow(row).GetCell(1).StringCellValue,
                        TIN = CHIRPHospitalSheet.GetRow(row).GetCell(2).CellType == CellType.Numeric ? CHIRPHospitalSheet.GetRow(row).GetCell(2).NumericCellValue.ToString() : CHIRPHospitalSheet.GetRow(row).GetCell(2).StringCellValue,
                        SDA = CHIRPHospitalSheet.GetRow(row).GetCell(3).StringCellValue,
                        CHIRPCLASS = CHIRPHospitalSheet.GetRow(row).GetCell(4).StringCellValue,
                        DHPContractRateIP = (CHIRPHospitalSheet.GetRow(row).GetCell(5).CellType == CellType.Numeric) ?  (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(5).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(5).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(5).StringCellValue)),
                        DHPContractRateIPBH = (CHIRPHospitalSheet.GetRow(row).GetCell(6).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(6).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(6).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(6).StringCellValue)),
                        DHPContractRateOP = (CHIRPHospitalSheet.GetRow(row).GetCell(7).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(7).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(7).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(7).StringCellValue)),
                        UHRIPIP = (CHIRPHospitalSheet.GetRow(row).GetCell(8).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(8).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(8).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(8).StringCellValue)),
                        UHRIPOP = (CHIRPHospitalSheet.GetRow(row).GetCell(9).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(9).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(9).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(9).StringCellValue)),
                        ACIAIP = (CHIRPHospitalSheet.GetRow(row).GetCell(10).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(10).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(10).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(10).StringCellValue)),
                        ACIAOP = (CHIRPHospitalSheet.GetRow(row).GetCell(11).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(11).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(11).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(11).StringCellValue)),
                        TotalCHIRIP = (CHIRPHospitalSheet.GetRow(row).GetCell(12).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(12).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(12).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(12).StringCellValue)),
                        TotalCHIRPOP = (CHIRPHospitalSheet.GetRow(row).GetCell(13).CellType == CellType.Numeric) ? (decimal)CHIRPHospitalSheet.GetRow(row).GetCell(13).NumericCellValue : (CHIRPHospitalSheet.GetRow(row).GetCell(13).StringCellValue == "n/a" ? 0 : Convert.ToDecimal(CHIRPHospitalSheet.GetRow(row).GetCell(13).StringCellValue))
                    };

                    CHIRPHospitalDTOs.Add(CHIRPHospitalDTO);
                }
            }

            using (var context = new DataContext())
            {
                var mappedCHIRPHospitals = mapper.ProjectTo<Domain.CHIRPHospital>(CHIRPHospitalDTOsEnumerables).ToList();

                var existingEntries = context.CHIRPHospitals.Any();
                if (existingEntries)
                {
                    Console.WriteLine("CHIRP Hospital entries already exist");
                }

                else
                {
                    context.CHIRPHospitals.AddRange(mappedCHIRPHospitals);
                    context.SaveChanges();
                    Console.WriteLine("Saved changes CHIRP Hospital entries");
                }

            }
        }
    }
}
