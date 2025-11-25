using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGWADProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AGWADProject.Services
{
    public class CarSearchService : ICarSearchService
    {
        private readonly AGDbContext _context;

        public CarSearchService(AGDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> SearchByMakeAsync(string make)
        {
            return await _context.Cars
                .Where(c => c.Make.ToLower().Contains(make.ToLower()))
                .Include(c => c.Category)
                .Include(c => c.FuelType)
                .Include(c => c.TractionType)
                .Include(c => c.TransmissionType)
                .ToListAsync();
        }
    }
}
