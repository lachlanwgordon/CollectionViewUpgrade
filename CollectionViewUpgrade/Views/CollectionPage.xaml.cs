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
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}