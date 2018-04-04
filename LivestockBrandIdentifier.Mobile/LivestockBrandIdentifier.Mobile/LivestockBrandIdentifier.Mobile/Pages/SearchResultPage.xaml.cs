using LivestockBrandIdentifier.Mobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LivestockBrandIdentifier.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchResultPage : ContentPage
	{
        private ICollection<LivestockBrandModel> _livestockBrands = new ObservableCollection<LivestockBrandModel>();
        private readonly LivestockBrandService _livestockBrandService = new LivestockBrandService();

        public SearchResultPage(LivestockBrandSearchModel search)
		{
			InitializeComponent();
            InitPage(search);
        }

        private void InitPage(LivestockBrandSearchModel search)
        {
            GetItems(search);
            ListView.ItemsSource = _livestockBrands;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ListView.SelectedItem != null)
            {
                var detailPage = new DetailPage(e.Item as LivestockBrandModel);

                await Navigation.PushAsync(detailPage);
            }
        }

        private void GetItems(LivestockBrandSearchModel search)
        {
            var searchResult = _livestockBrandService.Search(search);

            foreach (var item in searchResult.Items)
            {
                _livestockBrands.Add(item);
            }
        }
    }
}