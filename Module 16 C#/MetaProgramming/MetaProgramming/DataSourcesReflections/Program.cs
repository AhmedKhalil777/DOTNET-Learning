// See https://aka.ms/new-console-template for more information

using DataSourcesReflections;

var dataContext = new DataContext
{
    Products = new List<Product>()
    {
        new Product {ProductId = 1, ProductName = "TV"},
        new Product {ProductId = 2, ProductName = "Laptop"},
        new Product {ProductId = 3, ProductName = "Mouse"},
        new Product {ProductId = 4, ProductName = "keyboard"},
        new Product {ProductId = 5, ProductName = "Screen"},
    }
};

var listbox =new ListBox();
listbox.ValueMember = nameof(Product.ProductId);
listbox.DisplayMember = nameof(Product.ProductName);
listbox.DataSource = dataContext.Products;