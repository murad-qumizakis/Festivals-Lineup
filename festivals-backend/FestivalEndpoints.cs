using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
class FestivalEndpoints
{

    public void Configure(RouteGroupBuilder router)
    {

        router.MapGet("/", GetFestivals);
        router.MapPost("/Create", CreateFesitval);
        router.MapPut("/update/{id}", UpdateFestival);
        router.MapDelete("/delete/{id}", DeleteFestival);

        // GET
        async Task<List<Festival>> GetFestivals(FestivalDbContext db)
        {
            var festivals = await db.Festivals.Include(f => f.Artists).Select(f => new Festival
            {
                Id = f.Id,
                Name = f.Name,
                Location = f.Location,
                Date = f.Date,
                Genre = f.Genre,
                Artists = (List<Artist>)f.Artists.Select(a => new Artist
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = a.Country
                })
            }).ToListAsync();
            return festivals;
        }
        // POST
        async Task<IResult> CreateFesitval(FestivalDbContext db, Festival festival)
        {
            db.Festivals.Add(festival);
            await db.SaveChangesAsync();
            return Results.Created($"/api/festivals/{festival.Id}", festival);
        }
        // PUT
        async Task<IResult> UpdateFestival(FestivalDbContext db, int id, Festival festival)
        {
            if (id != festival.Id)
            {
                return Results.BadRequest();
            }

            db.Entry(festival).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Results.NoContent();
        }
        // DELETE
        async Task<IResult> DeleteFestival(FestivalDbContext db, int id)
        {
            var festivalToDelete = await db.Festivals.FindAsync(id);
            if (festivalToDelete == null)
            {
                return Results.NotFound();
            }
            db.Festivals.Remove(festivalToDelete);
            await db.SaveChangesAsync();
            return Results.Ok();
        }




    }
}