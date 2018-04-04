using LivestockBrandIdentifier.Mobile.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LivestockBrandIdentifier.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        private LivestockBrandSearchModel _search;

        public SearchPage()
        {
            InitializeComponent();
            InitPage();
        }

        private void InitPage()
        {
            ClearFields();
        }

        private void TiClear_Clicked(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void TiSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchResultPage(_search));
        }

        private void ClearFields()
        {
            _search = new LivestockBrandSearchModel
            {
                Paging = new Paging
                {
                    Sorting = Sort.Ascending,
                    ColumnName = "FarmName",
                    PageNumber = 1,
                    RecordsPerPage = 10

                }
            };

            SearchForm.BindingContext = _search;
        }
    }
}