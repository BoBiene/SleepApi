
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/sleep/{timeToSleep:int}", async (int timeToSleep) =>
{
    await Task.Delay(timeToSleep); 
    return Results.Ok($"Slept for {timeToSleep} milliseconds");
});

await app.RunAsync();
