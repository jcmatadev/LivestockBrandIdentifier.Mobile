namespace LivestockBrandIdentifier.Mobile.Models
{
    public class Paging
    {
        public string ColumnName;

        public int PageNumber;

        public Sort Sorting;

        public int RecordsPerPage;
    }

    public enum Sort
    {
        Ascending,
        Descending
    }
}
