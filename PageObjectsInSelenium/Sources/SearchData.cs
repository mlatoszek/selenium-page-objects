namespace PageObjectsInSelenium.Sources
{
    /// <summary>
    /// Dane do wyszukiwania
    /// </summary>
    public class SearchData
    {
        /// <summary>
        /// Identyfikator rekordu
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Termin do wyszukiwania
        /// </summary>        
        public string SearchTerm { get; set; }

        /// <summary>
        /// Rezultat który chcemy znaleść na stronie
        /// </summary>
        public string Result { get; set; }
    }

    /// <summary>
    /// Dane do wyszukiwania
    /// </summary>
    public class Names
    {
        /// <summary>
        /// Identyfikator rekordu
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Termin do wyszukiwania
        /// </summary>        
        public string Name { get; set; }
    }
}