var builder = WebApplication.CreateBuilder(args);

//Adiciona o servico de controller 
builder.Services.AddControllers();

var app = builder.Build();

//Adiona o mapeamento da controller 
app.MapControllers();

//app.UseHttpsRedirection();

app.Run();
