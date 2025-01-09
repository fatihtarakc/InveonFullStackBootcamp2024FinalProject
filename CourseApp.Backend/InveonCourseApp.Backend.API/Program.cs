var builder = WebApplication.CreateBuilder(args);
builder.AddApiLoggingWebApplicationBuilder();

// Add services to the container.
builder.Services
    .AddCoreServices(builder.Configuration)
    .AddDataAccessServices(builder.Configuration)
    .AddDataAccessConcreteServices(builder.Configuration)
    .AddCacheServices(builder.Configuration)
    .AddQueueServices(builder.Configuration)
    .AddBusinessConcreteServices(builder.Configuration)
    .AddBackgroundJobsServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddBackgroundJobsUseHangfireDashboardWithPathApplicationBuilder("/hangfire");
app.AddApiUseRequestLocalizationApplicationBuilder();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();