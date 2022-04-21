using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Entities;
using Test.Api.Repositories.Contracts;

namespace Test.Api.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly TestDbContext db;

        public BoxRepository(TestDbContext _db)
        {
            db = _db;
        }

        public async Task<Box> GetBox(int id)
        {
            return await db.Boxes.FindAsync(id);
        }

        public async Task<IEnumerable<Box>> GetBoxesForShed(int id)
        {
            return await db.Boxes.Where(x => x.ShedId == id).ToListAsync();
        }
    }
}
