# luncloud

## Doing
- Add Blazor WebAssembly GUI

## Ideas
- File upload
- File download
- Auth with users and sharing files
- Onion architecture
- Separate the layers enough that we later can add on ui from different frameworks, and possibly switch data layer implementation.
- Add Android kotlin GUI
- Add SQLite database
- Add other type of db, document or graph
- Add a gRPC service

## Get started
To restore dependencies and run app:

```bash
dotnet run --project .\src\WebApi\
```

## References
[ASP.NET Core clean architecture example](https://github.com/jasontaylordev/CleanArchitecture) by Jason Taylor


    // "http": {
    //   "commandName": "Project",
    //   "dotnetRunMessages": true,
    //   "launchBrowser": false,
    //   "applicationUrl": "http://localhost:5062",
    //   "environmentVariables": {
    //     "ASPNETCORE_ENVIRONMENT": "Development"
    //   }
    // },


    ## Temp stuff for blazor server
    using Domain;
using WebClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebClient._Imports).Assembly);

app.Run();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55)
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();