using VaidaGeorgeLab7.Models;

namespace VaidaGeorgeLab7;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    
    async void OnDeleteItem(object sender, EventArgs e)
    {
        var button = sender as Button;
        var product = button.BindingContext as Product;
        var shoplist = this.BindingContext as ShopList;

        await App.Database.DeleteListProductAsync(shoplist.ID, product.ID);
        OnAppearing();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        // aaaaa
        await Navigation.PushAsync(new ProductPage((ShopList)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }

}