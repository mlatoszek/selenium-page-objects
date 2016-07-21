using System;
using System.Linq;
using OpenQA.Selenium.Chrome;
using PageObjectsInSelenium.Bing;

namespace PageObjectsInSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Tworzy sterownik chrome'a (należy pamiętać o using: using OpenQA.Selenium.Chrome)
            var driver = new ChromeDriver();

            ///Tworzy instancję naszego page objectu przekazując sterownik do konstruktora
            BingMainPage mainPage = new BingMainPage(driver);

            ///Nawiguje do strony głównej bing
            mainPage.Navigate();

            ///Wyszukuje tekst na stronie
            mainPage.Search("Selenium page objects bing c#");

            ///Pobiera rezultaty
            var results = mainPage.GetResults();

            ///Iteruje się po każdym ze znalezionych rezultatów i wypisuje go na konsolę aplikacji
            foreach (var bingSearchResult in results)
            {
                Console.WriteLine(bingSearchResult);
            }

            ///Pobiera pierwszy rezultat z kolekcji
            var searchResult = results.First();

            ///Przechodzi do wybranego rezultatu
            mainPage.GoTo(searchResult);


            Console.ReadKey();
            driver.Quit();
        }
    }
}
