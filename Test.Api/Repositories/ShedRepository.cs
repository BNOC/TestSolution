using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Entities;
using Test.Api.Repositories.Contracts;

namespace Test.Api.Repositories
{
    public class ShedRepository : IShedRepository
    {
        private readonly TestDbContext db;

        public ShedRepository(TestDbContext _db)
        {
            db = _db;
        }

        public async Task<Shed> GetShed(int id)
        {
            // Do I populate it all here with includes?
            // db.Sheds.Include(b=>b.Boxes).Where()..
            
            return await db.Sheds.FindAsync(id);
        }
    }
}
