using LivestockBrandIdentifier.Mobile.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LivestockBrandIdentifier.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
            InitPage();
		}

        private void InitPage()
        {
            btnPickImage.Clicked += async (sender, e) =>
            {
                //btnPickImage.IsEnabled = false;
                Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

                if (stream != null)
                {
                    Image image = new Image
                    {
                        Source = ImageSource.FromStream(() => stream),
                        BackgroundColor = Color.Gray
                    };

                    TapGestureRecognizer recognizer = new TapGestureRecognizer();
                    recognizer.Tapped += (sender2, args) =>
                    {
                        (this as ContentPage).Content = PageLayout;
                        btnPickImage.IsEnabled = true;
                    };
                    image.GestureRecognizers.Add(recognizer);

                    (this as ContentPage).Content = image;
                }
                else
                {
                    btnPickImage.IsEnabled = true;
                }
            };
        }
    }
}