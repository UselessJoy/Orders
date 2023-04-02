using Orders.Model;
using Orders.Model.Entity;
using Orders.Service.ClientService;
using Orders.Service.OrderService;
using Orders.Service.ProductService;
using Orders.Service.OrderClientServie;
using Orders.Service.CheckService;
using System.Drawing;


var builder = WebApplication.CreateBuilder(args);

//Добавление зависимостей
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();
builder.Services.AddTransient<IDaoOrderProduct, DbDaoOrderProduct>();
builder.Services.AddTransient<IDaoProduct, DbDaoProduct>();
builder.Services.AddTransient<IDaoCheck, DbDaoCheck>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");



//client CRUD
app.MapGet("/client/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.AddClient(client);
});

app.MapPost("/client/delete/{id}", async (HttpContext context, IDaoClient dao, int id) =>
{
    return await dao.DeleteClient(id);
});

app.MapPost("/client/update", async (IDaoClient dao, Client client) =>
{
    return await dao.UpdateClient(client);
});

app.MapGet("/client/get/{id}", async (HttpContext context, IDaoClient dao, int id) =>
{
    return await dao.GetClientById(id);
});

//order CRUD
app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAllOrders();
});

app.MapPost("/order/add", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.AddOrder(order);
});

app.MapPost("/order/delete/{id}", async (HttpContext context, IDaoOrder dao, int id) =>
{
    return await dao.DeleteOrder(id);
});

app.MapPost("/order/update", async (IDaoOrder dao, Order order) =>
{
    return await dao.UpdateOrder(order);
});

app.MapGet("/order/get/{id}", async (HttpContext context, IDaoOrderProduct dao, int id) =>
{
    return await dao.GetOrderProductById(id);
});


//product CRUD
app.MapGet("/product/all", async (HttpContext context, IDaoProduct dao) =>
{
    return await dao.GetAllProducts();
});

app.MapPost("/product/add", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.AddProduct(product);
});

app.MapPost("/product/delete/{id}", async (HttpContext context, IDaoProduct dao, int id) =>
{
    return await dao.DeleteProduct(id);
});

app.MapPost("/product/update", async (IDaoProduct dao, Product product) =>
{
    return await dao.UpdateProduct(product);
});

app.MapGet("/product/get/{id}", async (HttpContext context, IDaoProduct dao, int id) =>
{
    return await dao.GetProductById(id);
});


//orderProduct CRUD
app.MapGet("/order_product/all", async (HttpContext context, IDaoOrderProduct dao) =>
{
    return await dao.GetAllOrdersProducts();
});

app.MapPost("/order_product/add", async (HttpContext context, OrderProduct orderProduct, IDaoOrderProduct dao) =>
{
    return await dao.AddOrderProduct(orderProduct);
});

app.MapPost("/order_product/delete/{id}", async (HttpContext context, IDaoOrderProduct dao, int id) =>
{
    return await dao.DeleteOrderProduct(id);
});

app.MapPost("/order_product/update", async (IDaoOrderProduct dao, OrderProduct orderProduct) =>
{
    return await dao.UpdateOrderProduct(orderProduct);
});

app.MapGet("/order_product/get/{id}", async (HttpContext context, IDaoOrderProduct dao, int id) =>
{
    return await dao.GetOrderProductById(id);
});


//check info/summ
app.MapGet("/check/info/{orderId}", async (HttpContext context, IDaoCheck dao, int orderId) =>
{
    return await dao.CheckInfo( orderId);
});

app.MapGet("/check/summ/{orderId}", async (HttpContext context, IDaoCheck dao, int orderId) =>
{
    return await dao.CheckSumm(orderId);
});

app.Run();
