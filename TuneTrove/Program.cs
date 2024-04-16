using TuneTrove_DAL;
using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Presentation_Interfaces;
using TuneTrove_Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBandRepository, BandRepository>();
builder.Services.AddScoped<IBandSetlistRepository, BandSetlistRepository>();
builder.Services.AddScoped<IMuzikantBandRepository, MuzikantBandRepository>();
builder.Services.AddScoped<IMuzikantNummerRepository, MuzikantNummerRepository>();
builder.Services.AddScoped<IMuzikantRepository, MuzikantRepository>();
builder.Services.AddScoped<IMuzikantSetlistRepository, MuzikantSetlistRepository>();
builder.Services.AddScoped<INummerRepository, NummerRepository>();
builder.Services.AddScoped<INummerSetlistRepository, NummerSetlistRepository>();
builder.Services.AddScoped<ISetlistRepository, SetlistRepository>();

builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<IMuzikantService, MuzikantService>();
builder.Services.AddScoped<INummerService, NummerService>();
builder.Services.AddScoped<ISetlistService, SetlistService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRazorPages();
builder.Services.AddSession();

var app = builder.Build();


// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
