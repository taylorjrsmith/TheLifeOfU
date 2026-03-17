using Microsoft.EntityFrameworkCore;
using TheTaleOfU;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TheTaleOfUContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TheTaleOfUContext")));

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors();

// ── Scenarios ──────────────────────────────────────────────────────
app.MapGet("/api/scenarios", async (TheTaleOfUContext db) =>
    await db.Scenarios.Include(s => s.Options).ToListAsync());

app.MapGet("/api/scenarios/{id:int}", async (int id, TheTaleOfUContext db) =>
{
    var scenario = await db.Scenarios.Include(s => s.Options)
                                     .FirstOrDefaultAsync(s => s.Id == id);
    return scenario is null ? Results.NotFound() : Results.Ok(scenario);
});

app.MapPost("/api/scenarios", async (Scenario scenario, TheTaleOfUContext db) =>
{
    db.Scenarios.Add(scenario);
    await db.SaveChangesAsync();
    return Results.Created($"/api/scenarios/{scenario.Id}", scenario);
});

app.MapPut("/api/scenarios/{id:int}", async (int id, Scenario updated, TheTaleOfUContext db) =>
{
    var scenario = await db.Scenarios.FindAsync(id);
    if (scenario is null) return Results.NotFound();
    scenario.ScenarioDescription = updated.ScenarioDescription;
    scenario.AllowedPlayerTypes = updated.AllowedPlayerTypes;
    scenario.IsEndOfScenarioRoute = updated.IsEndOfScenarioRoute;
    scenario.EndOfEventMethodName = updated.EndOfEventMethodName;
    await db.SaveChangesAsync();
    return Results.Ok(scenario);
});

app.MapDelete("/api/scenarios/{id:int}", async (int id, TheTaleOfUContext db) =>
{
    var scenario = await db.Scenarios.FindAsync(id);
    if (scenario is null) return Results.NotFound();
    db.Scenarios.Remove(scenario);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ── Options ────────────────────────────────────────────────────────
app.MapGet("/api/scenarios/{id:int}/options", async (int id, TheTaleOfUContext db) =>
    await db.Options.Where(o => o.OriginScenarioId == id).ToListAsync());

app.MapPost("/api/options", async (Option option, TheTaleOfUContext db) =>
{
    db.Options.Add(option);
    await db.SaveChangesAsync();
    return Results.Created($"/api/options/{option.Id}", option);
});

app.MapDelete("/api/options/{id:int}", async (int id, TheTaleOfUContext db) =>
{
    var option = await db.Options.FindAsync(id);
    if (option is null) return Results.NotFound();
    db.Options.Remove(option);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ── Items ──────────────────────────────────────────────────────────
app.MapGet("/api/items", async (TheTaleOfUContext db) => await db.Items.ToListAsync());

app.MapPost("/api/items", async (Item item, TheTaleOfUContext db) =>
{
    db.Items.Add(item);
    await db.SaveChangesAsync();
    return Results.Created($"/api/items/{item.Id}", item);
});

app.Run();
