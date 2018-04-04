using LivestockBrandIdentifier.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LivestockBrandIdentifier.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
    {
        public DetailPage(LivestockBrandModel livestockBrandModel)
        {
            InitializeComponent();
            InitPage(livestockBrandModel);
        }

        private void InitPage(LivestockBrandModel livestockBrandModel)
        {
            BindingContext = livestockBrandModel;
        }
    }
}