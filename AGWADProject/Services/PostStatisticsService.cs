using AGWADProject.Models;
using AGWADProject.Services.Interfaces;

namespace AGWADProject.Services
{
    public class PostStatisticsService : IPostStatisticsService
    {
        private readonly AGDbContext _context;

        public PostStatisticsService(AGDbContext context)
        {
            _context = context;
        }

        public int GetTotalPostCount()
        {
            return _context.Posts.Count();
        }

        public int GetPostCountByPerson(int personId)
        {
            return _context.Posts.Count(p => p.PersonId == personId);
        }

        public int GetPostCountByCar(int carId)
        {
            return _context.Posts.Count(p => p.CarId == carId);
        }
    }
}
