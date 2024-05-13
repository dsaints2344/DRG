using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ISheet ratesSheet;

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
                ratesSheet = workbook.GetSheetAt(4);
            }
        }
    }
}
