using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using ModulesBLL;
using UI.WebAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//builder.Services.AddFluentValidation(fv =>
//    fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly));

builder.Services.AddSwaggerGen();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterAssemblyModules(typeof(ModulesBLL.CommandsAndQueriesModule).Assembly);
    containerBuilder.RegisterAssemblyModules(typeof(ModulesDAL.UnitOfWorkModule).Assembly);
    containerBuilder.RegisterModule<ModelMappingModule>();
    containerBuilder.RegisterMediatR(typeof(Program).Assembly);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.MapControllers();
app.Run();

