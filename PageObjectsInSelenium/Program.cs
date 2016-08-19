using System;
using System.Linq;
using OpenQA.Selenium.Chrome;
using PageObjectsInSelenium.Bing;
using PageObjectsInSelenium.Sources;

namespace PageObjectsInSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarujemy źródło z którego będziemy pobierać dane do wyszukiwania
            IDataSource source = new CsvDataSource();

            // Wołamy metodę która pobiera nam dane do wyszukiwania
            var dataSource = source.GetSearchData();

            ///Tworzy sterownik chrome'a (należy pamiętać o using: using OpenQA.Selenium.Chrome)
            var driver = new ChromeDriver();

            ///Tworzy instancję naszego page objectu przekazując sterownik do konstruktora
            BingMainPage mainPage = new BingMainPage(driver);

            foreach (var searchData in dataSource)
            {
                ///Nawiguje do strony głównej bing
                mainPage.Navigate();

                ///Wyszukuje tekst na stronie
                mainPage.Search(searchData.SearchTerm);

                ///Pobiera rezultaty
                var results = mainPage.GetResults();

                ///Iteruje się po każdym ze znalezionych rezultatów i wypisuje go na konsolę aplikacji
                foreach (var bingSearchResult in results)
                {
                    Console.WriteLine(bingSearchResult);
                }

                ///Pobiera pierwszy rezultat z kolekcji
                var searchResult = results
                    .Where(result => result.Text == searchData.Result)
                    .First();

                ///Przechodzi do wybranego rezultatu
                mainPage.GoTo(searchResult);
            }            


            Console.ReadKey();
            driver.Quit();
        }
    }
}
