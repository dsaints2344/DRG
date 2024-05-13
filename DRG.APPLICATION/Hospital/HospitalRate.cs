using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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
                    // TODO: Add logic for handling related Rates and hospitals
                }
            }

        }
    }
}
