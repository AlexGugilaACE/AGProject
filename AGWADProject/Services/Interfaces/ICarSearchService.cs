using System.Collections.Generic;
using System.Threading.Tasks;
using AGWADProject.Models;

namespace AGWADProject.Services
{
    public interface ICarSearchService
    {
        Task<List<Car>> SearchByMakeAsync(string make);
    }
}