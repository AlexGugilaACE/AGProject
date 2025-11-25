using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AGWADProject.Data;
using AGWADProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class PostService : IPostService
{
    private readonly AGDbContext _context;

    public PostService(AGDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _context.Posts
            .Include(p => p.Car)
            .Include(p => p.Person)
            .ToListAsync();
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await _context.Posts
            .Include(p => p.Car)
                .ThenInclude(c => c.TransmissionType)
            .Include(p => p.Car)
                .ThenInclude(c => c.FuelType)
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> CreatePostAsync(Post post, IFormFile? coverPhoto)
    {
        if (coverPhoto != null && coverPhoto.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = System.Guid.NewGuid().ToString() + Path.GetExtension(coverPhoto.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await coverPhoto.CopyToAsync(stream);

            post.CoverPhotoPath = "/uploads/" + fileName;
        }

        _context.Posts.Add(post);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdatePostAsync(Post post)
    {
        var existingPost = await _context.Posts.FindAsync(post.Id);
        if (existingPost == null) return false;

        existingPost.Title = post.Title;
        existingPost.Description = post.Description;
        existingPost.Price = post.Price;
        existingPost.PostedOn = post.PostedOn;
        existingPost.PersonId = post.PersonId;
        existingPost.CarId = post.CarId;
        existingPost.PhoneNumber = post.PhoneNumber;
      

        _context.Posts.Update(existingPost);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return false;

        _context.Posts.Remove(post);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public IEnumerable<Car> GetAllCars()
    {
        return _context.Cars.ToList();
    }

    public IEnumerable<Person> GetAllPersons()
    {
        return _context.Persons.ToList();
    }

    public async Task<IEnumerable<Post>> GetPostsByCarIdAsync(int carId)
    {
        return await _context.Posts
            .Include(p => p.Car)
            .Include(p => p.Person)
            .Where(p => p.CarId == carId)
            .ToListAsync();
    }
}
