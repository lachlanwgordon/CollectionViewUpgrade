using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CollectionViewUpgrade.Views
{
    public partial class PresentationCarouselPage : ContentPage
    {
        //static Shell Shell;
        public async void LogoClicked(object sender, EventArgs e)
        {
            //if (Shell == null)
            //{
            //    Shell = Shell.Current;
            //}
            //if (Application.Current.MainPage is ContentPage)
            //{
            //    Application.Current.MainPage = new ContentPage();
            //    await Task.Delay(500);
            //    Application.Current.MainPage = Shell;
            //}
            //else
            //{
            //    Application.Current.MainPage = new ContentPage();
            //    await Task.Delay(500);

            //    Application.Current.MainPage = new PresentationCarouselPage();
            //    Application.Current.MainPage.BindingContext = this.BindingContext;
            //}

            if (Shell.Current.Navigation.ModalStack.Count > 0)
            {
                await Shell.Current.Navigation.PopModalAsync();
            }
            else
            {
                var item = TheCarousel.CurrentItem;
                var items = (TheCarousel.ItemsSource as Object[]).ToList();



                var index = item == null ? 0 : items.IndexOf(item);
                await Shell.Current.Navigation.PushModalAsync(new PresentationCarouselPage(index));
            }





        }

        public PresentationCarouselPage()
        {
            InitializeComponent();
        }
        public PresentationCarouselPage(int index)
        {
            InitializeComponent();

            var items = (TheCarousel.ItemsSource as Object[]).ToList();
            var item = items[index];
            TheCarousel.CurrentItem = item;
            TheCarousel.Margin = new Thickness(0, 0, 0, 100);
            logo.Margin = new Thickness(0);
        }
    }
}