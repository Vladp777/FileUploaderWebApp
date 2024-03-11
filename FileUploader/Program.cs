using Azure.Storage.Blobs;
using FileUploader.Components;
using FileUploader.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cVGhNYVJ2WmFZfVpgdVRMYFRbRn5PMyBoS35RckVgWH5fcXVRQ2ZZU0F0");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage")));
builder.Services.AddSingleton<IBlobService, BlobService>();

builder.Services.AddSyncfusionBlazor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
