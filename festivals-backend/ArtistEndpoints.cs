using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
class ArtistEndpoints
{

    public void Configure(RouteGroupBuilder router)
    {

        router.MapGet("/", GetArtists);
        router.MapPost("/Create", CreateArtist);
        router.MapPut("/update/{id}", UpdateArtist);
        router.MapDelete("/delete/{id}", DeleteArtist);

        // GET
        async Task<IResult> GetArtists(FestivalDbContext db)
        {
            var artists = await db.Artists.Include(a => a.Festival).ToListAsync();
            return Results.Json(artists, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReferenceHandler = ReferenceHandler.Preserve
            }, statusCode: 200);
        }
        // POST
        async Task<IResult> CreateArtist(FestivalDbContext db, CreateArtistPayload artist)
        {
            var creatingArtist = new Artist
            {
                Name = artist.Name,
                Country = artist.Country
            };
            var festival = db.Festivals.Find(artist.FestivalId);
            if (festival != null)
            {
                creatingArtist.Festival = festival;
            }
            db.Artists.Add(creatingArtist);
            await db.SaveChangesAsync();
            return Results.Json(creatingArtist, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReferenceHandler = ReferenceHandler.Preserve
            }, statusCode: 200);
        }
        // PUT
        async Task<IResult> UpdateArtist(FestivalDbContext db, int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return Results.BadRequest();
            }

            db.Entry(artist).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Results.NoContent();
        }
        // DELETE
        async Task<IResult> DeleteArtist(FestivalDbContext db, int id)
        {
            var artistToDelete = await db.Artists.FindAsync(id);
            if (artistToDelete == null)
            {
                return Results.NotFound();
            }
            db.Artists.Remove(artistToDelete);
            await db.SaveChangesAsync();
            return Results.Ok();
        }




    }
}


