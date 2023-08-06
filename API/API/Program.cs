using Persistence;
using Adapters;
using Domain.Base;
using FluentValidation;
using MediatR;
using System.Reflection;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });


});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar injección de dependencias
builder.Services.AddPersistenceServices();
builder.Services.AddAdapterServices();

const string ApplicationAssembleName = "Application";
var applicationAssemble = Assembly.Load(ApplicationAssembleName);
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblies(applicationAssemble);
});
AssemblyScanner.FindValidatorsInAssembly(Assembly.Load("Application")).ForEach(pair =>
{
    // RegisterValidatorsFromAssemblyContaing does this:
    builder.Services.Add(ServiceDescriptor.Scoped(pair.InterfaceType, pair.ValidatorType));
    // Also register it as its concrete type as well as the interface type
    builder.Services.Add(ServiceDescriptor.Scoped(pair.ValidatorType, pair.ValidatorType));

});

var app = builder.Build();

Config.Instance.ConnectionString = app.Configuration.GetConnectionString("medical-connetion");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
