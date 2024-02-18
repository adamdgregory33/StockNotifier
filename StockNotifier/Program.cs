

using StockNotifier.src;
using StockNotifier.src.Clients.Downstream;
using StockNotifier.src.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Would add inMemory for dev only (if other impls existed)
builder.Services.AddSingleton<ITickerInfoClient, InMemoryTickerInforClient>();
builder.Services.AddSingleton<INotifyRepository, InMemoryNotifyRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
