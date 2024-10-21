using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/", () => new { name = "Stephany Batista", age = 35 });
app.MapGet("/AddHeader", (HttpResponse response) =>{
    response.Headers.Add("Teste", "Stephany Batista");
    return new { name = "Stephany Batista", age = 35 };
});

app.MapPost("/products", (Product product) =>{
    ProductRepository.Add(product);
});

//api.app.com/user/{code}
app.MapGet("/products/{code}", ([FromRoute] string code) =>{
    var product = ProductRepository.GetProductByCode(code);
    return product;
});

app.MapPut("/products", (Product product) =>{
    var productSaved = ProductRepository.GetProductByCode(product.Code);
    productSaved.Name = product.Name;
});

app.MapDelete("/products/{code}", ([FromRoute] string code) =>{
    var productSaved = ProductRepository.GetProductByCode(code);
    ProductRepository.Remove(productSaved);

});

// //api.app.com/users?datastart={date}&dataend={date}
// app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dataEnd) => {
//     return dateStart + " - " + dataEnd;
// });

ProductRepository.Add(new Product("8", "Micro-ondas"));
ProductRepository.Add(new Product("5", "Torradeira"));

app.Run();


public static class ProductRepository{
    public static List<Product> Products { get; set; }


    // public ProductRepository(){
    //     Products = new List<Product>();
    // }

    public static void Add(Product product)    {
        if (Products == null)
        {
            Products = new List<Product>();
        }
        Products.Add(product);
    }

    public static Product GetProductByCode(string code)    {
        return Products.FirstOrDefault(p => p.Code == code);
    }

    public static void Remove(Product product)    {
        Products.Remove(product);
    }

}

public class Product{
    public string Code { get; set; }
    public string Name { get; set; }

    // Construtor com parâmetros
    public Product(string code, string name)    {
        Code = code;
        Name = name;
    }
}