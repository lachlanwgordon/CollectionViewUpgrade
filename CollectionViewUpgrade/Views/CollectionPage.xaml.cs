using System;
using CollectionViewUpgrade.ViewModels;
using Xamarin.Forms;


namespace CollectionViewUpgrade.Views
{
    public partial class CollectionPage : ContentPage
    {
        public CollectionViewModel ViewModel => BindingContext as CollectionViewModel;
        public CollectionPage()
        {
            BindingContext = new CollectionViewModel();
            InitializeComponent();
        }
    }
}