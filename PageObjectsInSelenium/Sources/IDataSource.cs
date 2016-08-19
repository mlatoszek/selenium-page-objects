using System.Collections.Generic;

namespace PageObjectsInSelenium.Sources
{
    /// <summary>
    /// Interfejs opisujący jak ma wyglądać źródło danych
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Zwraca dane do wyszukiwania pobrane z pliku/bazy danych (w zależności od źródła)
        /// </summary>
        /// <returns></returns>
        List<SearchData> GetSearchData();
    }
}