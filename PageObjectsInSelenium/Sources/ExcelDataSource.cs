using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PageObjectsInSelenium.Sources
{
    public class ExcelDataSource : IDataSource
    {
        /// <summary>
        /// Zwraca dane do wyszukiwania pobrane z pliku/bazy danych (w zależności od źródła)
        /// </summary>
        /// <returns></returns>
        public List<SearchData> GetSearchData()
        {
            //Otwiera "Excela"
            var pck = new OfficeOpenXml.ExcelPackage();

            //Wczytuje 
            pck.Load(File.OpenRead("SearchData.xlsx"));
            //Odnajdujemy Worksheet o nazwie Sheet1 
            var ws = pck.Workbook.Worksheets.Where(x=>x.Name == "Sheet1").First();

            List<SearchData> results = new List<SearchData>();
            for (int i = 2; i <= ws.Dimension.Rows; i++)
            {
                SearchData searchData = new SearchData();
                //Pobieramy search term z kolumny 1
                searchData.SearchTerm = ws.Cells[i, 1].Text;
                //Pobieramy search result z kolumny 2
                searchData.Result = ws.Cells[i, 2].Text;
                results.Add(searchData);
            }
            return results;
        }
    }
}
