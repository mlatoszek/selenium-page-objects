using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectsInSelenium.Sources
{
    class DatabaseDataSource : IDataSource
    {
        public List<SearchData> GetSearchData()
        {
            SearchDataDbContext context = new SearchDataDbContext();
            var data = context.SearchData.ToList();

            var result =
                from name in context.Names
                join searchData in context.SearchData on name.Id equals searchData.Id
                select new {Id = name.Id, Name = name.Name, SearchData = searchData.SearchTerm};
            

            return data;
        }
    }
}
