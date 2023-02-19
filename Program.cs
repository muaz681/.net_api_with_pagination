using FinalApi.Data;
using FinalApi.IServices.IPerson;
using FinalApi.IServices.ISProcedure;
using FinalApi.Pagination.Services.CService;
using FinalApi.Pagination.Services.IService;
using FinalApi.Service.PersonService;
using FinalApi.Service.StoredProcedureService;
using FinalApi.StoreProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AdventureWorks2019Context>();
//builder.Services.AddDbContext<ERP_AppsContext>();
builder.Services.AddDbContext<ErpAppsContext>();

builder.Services.AddScoped<ISPEmployeJob, SPAEmployeService>();
builder.Services.AddDbContext<ERP_HR_Context>();

builder.Services.AddDbContext<AdventureWorks2019Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Adventure_Connection"));
});
//builder.Services.AddDbContext<ErpAppsContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Apps_Connection"));
//});
builder.Services.AddDbContext<ErpAppsContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("Apps_Connection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});
builder.Services.AddControllers();
builder.Services.AddTransient<IPersonService, PersonAppService>();
builder.Services.AddTransient<ISPServices, SPAppService>();
builder.Services.AddSingleton<IConfigManager, ConfigManager>();
//builder.Services.AddTransient<IConfigManager, ConfigManager>();
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
