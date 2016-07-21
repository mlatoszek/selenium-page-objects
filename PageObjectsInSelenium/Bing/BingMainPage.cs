using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectsInSelenium.Bing
{
    /// <summary>
    /// Page Object dla strony bing.com
    /// </summary>
    public class BingMainPage
    {
        /// <summary>
        /// Driver (np. chrome)        
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Adres strony
        /// </summary>
        private string url = "http://www.bing.com/";


        /// <summary>
        /// Textbox do wyszukiwania na stronie bing.com
        /// </summary>
        [FindsBy(How = How.Id, Using = "sb_form_q")] // Atrybut 
        public IWebElement SearchBox { get; set; }

        /// <summary>
        /// Button do wyszukiwania na stronie bing.com
        /// </summary>
        [FindsBy(How = How.Id, Using = "sb_form_go")]
        public IWebElement SubmitButton { get; set; }

        /// <summary>
        /// Rezultaty wyszukiwania, przykładowo:
        /// <li class="b_algo" data-bm="6">
        ///     <div class="b_title">
        ///     <h2>
        ///         <a href="http://www.ozspeedtest.com/" h="ID=SERP,5101.1">Speed <strong>Test</strong> - Home - <strong>Oz Broadband</strong> …</a>
        ///     </h2>
        ///     <div class="b_suffix b_secondaryText nowrap">
        ///         <a href="http://www.microsofttranslator.com/bv.aspx?ref=SERP&amp;br=ro&amp;mkt=en-ww&amp;dl=pl&amp;lp=EN_PL&amp;a=http%3a%2f%2fwww.ozspeedtest.com%2f" h="ID=SERP,5107.1">Przetłumacz tę stronę</a>
        ///     </div>
        ///     </div>
        ///     <div class="b_caption">
        ///         <div class="b_snippet">
        ///         <div class="b_attribution" u="1|5048|4850200768545531|i-1kImG4J1Kdnb7QWhrOX9mlcpq7YYLp">
        ///         <cite>www.ozspeed<strong>test</strong>.com</cite>
        ///         <a href="#" aria-label="Czynności dla tej witryny" aria-haspopup="true">
        ///             <span class="c_tlbxTrg">
        ///                 <span class="c_tlbxTrgIcn sw_ddgn"></span>
        ///                 <span class="c_tlbxH" h="BASE:CACHEDPAGEDEFAULT" k="SERP,5102.1"></span>
        ///             </span>
        ///         </a>
        ///     </div><p><strong>Oz Broadband Speed Test Test</strong> both download speed and upload speed of your Internet connection, whether it be Dialup, ADSL, ADSL2, ADSL2+, Cable, 3G, 4G, Wireless or ...</p></div><div class="sa_uc"><ul class="b_vList"><li class="b_annooverride"><div class="b_factrow"><a href="http://www.ozspeedtest.com/bandwidth-test/" h="ID=SERP,5235.1">Bandwidth Test</a> · <a href="http://www.ozspeedtest.com/bandwidth-test/optus-speed-test/1/" h="ID=SERP,5236.1">Optus Speed Test</a> · <a href="http://www.ozspeedtest.com/m/" h="ID=SERP,5237.1">iPhone Speed Test</a> · <a href="http://www.ozspeedtest.com/news/" h="ID=SERP,5238.1">News</a> · <a href="http://www.ozspeedtest.com/users/signup/" h="ID=SERP,5239.1">Signup</a> · <a href="http://www.ozspeedtest.com/contact/" h="ID=SERP,5240.1">Contact Us</a></div></li></ul></div></div></li>
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "b_algo")]
        public IList<IWebElement> SearchResults { get; set; }

        /// <summary>
        /// Domyślny konstruktor przyjmujący sterownik WebDriver (W tym wypadku chrome). Sterownik podawany jest poprzez interfejs
        /// także może być tutaj również użyty dowolny inny (np. firefox, IE, phantomjs)
        /// </summary>
        public BingMainPage(IWebDriver driver)
        {
            // Przypisanie do globalnej zmiennej naszego sterownika (podawanego do konstruktora)
            this.driver = driver;
            // Metoda Selenium.Support do webobject wypełniająca nam zdefiniowane property
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Nawiguje do głównej strony bing
        /// </summary>
        public void Navigate()
        {
            driver.Url = url;
            driver.Navigate();
        }

        /// <summary>
        /// Wpisuje w pole wyszukiwania podany tekst i klika guzik submit
        /// </summary>
        /// <param name="text">Tekst do wyszukiwania</param>
        public void Search(string text)
        {
            SearchBox.SendKeys(text);
            SubmitButton.Submit();
        }


        /// <summary>
        /// Pobiera rezultaty wyszukiwania w formie URL i Tekst
        /// </summary>
        /// <returns>
        /// IEnumerable - generyczna interfejs dla kolekcji (dzięki niemu mogę zwrócić np. tablicę lub listę)
        /// </returns>
        public IEnumerable<BingSearchResult> GetResults()
        {
            List<BingSearchResult> results = new List<BingSearchResult>();
            foreach (var searchResult in SearchResults)
            {
                BingSearchResult result = new BingSearchResult();
                var aHref = searchResult.FindElement(By.CssSelector("a"));
                result.Text = aHref.Text;
                result.Url = aHref.GetAttribute("href");
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Przechodzi do podanego rezultatu wyszukiwania
        /// </summary>
        /// <param name="result"></param>
        public void GoTo(BingSearchResult result)
        {
            driver.Url = result.Url;
            driver.Navigate();
        }
    }

    /// <summary>
    /// Rezultat wyszukiwania
    /// </summary>
    public class BingSearchResult
    {
        /// <summary>
        /// Adres rezultatu
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Tekst (tytuł strony)
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Formatuje rezultat wyszukiwania (po to aby ładnie wypisać go na konsolę)
        /// </summary>
        public override string ToString()
        {
            return $"Url: {Url}, Text: {Text}";
        }
    }
}
