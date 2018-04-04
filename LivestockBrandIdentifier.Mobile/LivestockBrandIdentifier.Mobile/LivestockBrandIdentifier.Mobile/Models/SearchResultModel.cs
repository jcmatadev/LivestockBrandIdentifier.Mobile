using System.Collections.Generic;

namespace LivestockBrandIdentifier.Mobile.Models
{
    public class SearchResultModel<T>
    {
        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
