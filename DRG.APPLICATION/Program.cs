using DRG.Application.DTOs;
using DRG.Persistence;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var pricingWorkbookPath = @"C:\Repos\DRG\DCM Dev Test Project\Price Sheet Calculation.xlsx";
        XSSFWorkbook workbook;
        List<APRDRGV36DTO> v36PricingList = new List<APRDRGV36DTO>();
        using (FileStream file = new FileStream(pricingWorkbookPath, FileMode.Open, FileAccess.Read))
        {
            workbook = new XSSFWorkbook(file);
        }

        ISheet v36PricingSheet = workbook.GetSheetAt(3);
        
        for (int row = 4; row <= v36PricingSheet.LastRowNum; row++)
        {
            // Console.WriteLine(v36PricingSheet.GetRow(row).GetCell(4).CellType == CellType.Numeric ? (int?)v36PricingSheet.GetRow(row).GetCell(4).NumericCellValue : 0);
            if (v36PricingSheet.GetRow(row) != null)
            {
                APRDRGV36DTO aprV36Dto = new APRDRGV36DTO()
                {
                    APRDRG = v36PricingSheet.GetRow(row).GetCell(0).StringCellValue,
                    SOIScore = int.Parse(v36PricingSheet.GetRow(row).GetCell(1).StringCellValue),
                    CombinedSOI = v36PricingSheet.GetRow(row).GetCell(2).StringCellValue,
                    Description = v36PricingSheet.GetRow(row).GetCell(3).StringCellValue,
                    V36RelativeWeight = v36PricingSheet.GetRow(row).GetCell(4).CellType == CellType.Numeric ? (decimal?)v36PricingSheet.GetRow(row).GetCell(4).NumericCellValue : 0,
                    MLOS = v36PricingSheet.GetRow(row).GetCell(5).CellType == CellType.Numeric ? (double?)v36PricingSheet.GetRow(row).GetCell(5).NumericCellValue : 0,
                    DayOutlierThreshold = (v36PricingSheet.GetRow(row).GetCell(6).CellType == CellType.Numeric ? (int?)v36PricingSheet.GetRow(row).GetCell(6).NumericCellValue : 0)
                };
                v36PricingList.Add(aprV36Dto);
            }
        }

    }
}