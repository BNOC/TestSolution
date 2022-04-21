using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Entities;
using Test.Api.Repositories.Contracts;

namespace Test.Api.Repositories
{
    public class ThingRepository : IThingRepository
    {
        private readonly TestDbContext db;

        public ThingRepository(TestDbContext _db)
        {
            db = _db;
        }

        public async Task<Thing> GetThing(int id)
        {
            return await db.Things.FindAsync(id);
        }

        public async Task<IEnumerable<Thing>> GetThingsForBox(int id)
        {
            return await db.Things.Where(x => x.BoxId == id).ToListAsync();
        }
    }
}
