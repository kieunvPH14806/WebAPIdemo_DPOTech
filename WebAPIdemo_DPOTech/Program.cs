using Microsoft.EntityFrameworkCore;
using WebAPIdemo_DPOTech.Buisness.ServiceForController;
using WebAPIdemo_DPOTech.DB.DbWebContext;
using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbWebContext>(connection =>
{
    connection.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
});
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<NewsServiceController>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
