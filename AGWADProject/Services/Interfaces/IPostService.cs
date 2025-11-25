using System.Collections.Generic;
using System.Threading.Tasks;
using AGWADProject.Models;
using Microsoft.AspNetCore.Http;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post?> GetPostByIdAsync(int id);
    Task<bool> CreatePostAsync(Post post, IFormFile? coverPhoto);
    Task<bool> UpdatePostAsync(Post post);
    Task<bool> DeletePostAsync(int id);

    IEnumerable<Car> GetAllCars();
    IEnumerable<Person> GetAllPersons();

    Task<IEnumerable<Post>> GetPostsByCarIdAsync(int carId);
}
