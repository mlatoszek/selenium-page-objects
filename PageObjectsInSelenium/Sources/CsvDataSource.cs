using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectsInSelenium.Sources
{
    public class CsvDataSource : IDataSource
    {
        /// <summary>
        /// Zwraca dane do wyszukiwania pobrane z pliku/bazy danych (w zależności od źródła)
        /// </summary>
        /// <returns></returns>
        public List<SearchData> GetSearchData()
        {
            List<SearchData> results = new List<SearchData>();

            //Otwiera strumień do pliku
            using (var stream = File.OpenRead("SearchData.csv"))
            {
                //Tworzy obiekt klasy StreamReader 
                var streamReader = new StreamReader(stream);
                string line;
                //Omijamy pierwszą linijkę
                streamReader.ReadLine();

                while ((line = streamReader.ReadLine()) != null)
                {
                    //Dzielimy linię na stringi  oddzielone znakiem ;
                    string[] columns = line.Split(';');
                    SearchData searchData = new SearchData();
                    searchData.SearchTerm = columns[0];
                    searchData.Result = columns[1];

                    results.Add(searchData);
                }                
            }

            
            return results;
        }
    }
}
