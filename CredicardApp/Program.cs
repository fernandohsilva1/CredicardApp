using CredicardApp.Components;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddHttpClient("API", client =>
{
    var apiBaseAddress = builder.Configuration["ApiBaseAddress"];
    if (string.IsNullOrEmpty(apiBaseAddress))
    {
        throw new InvalidOperationException("API base não está configurada corretamente");
    }
    client.BaseAddress = new Uri(apiBaseAddress);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
