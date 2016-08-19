namespace PageObjectsInSelenium.Sources
{
    /// <summary>
    /// Dane do wyszukiwania
    /// </summary>
    public class SearchData
    {
        /// <summary>
        /// Termin do wyszukiwania
        /// </summary>        
        public string SearchTerm { get; set; }

        /// <summary>
        /// Rezultat który chcemy znaleść na stronie
        /// </summary>
        public string Result { get; set; }
    }
}