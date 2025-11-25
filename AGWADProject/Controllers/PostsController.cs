using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using AGWADProject.Models;
using AGWADProject.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using AGWADProject.Services;

namespace AGWADProject.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPostStatisticsService _postStats;
        private readonly ICarSearchService _carSearchService;

        public PostsController(IPostService postService, IPostStatisticsService postStats, ICarSearchService carSearchService)
        {
            _postService = postService;
            _postStats = postStats;
            _carSearchService = carSearchService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllPostsAsync();
            ViewBag.TotalPostCount = _postStats.GetTotalPostCount();
            return View(posts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var post = await _postService.GetPostByIdAsync(id.Value);
            if (post == null) return NotFound();

            return View(post);
        }

        public async Task<IActionResult> SearchByMake(string make)
        {
            if (string.IsNullOrWhiteSpace(make))
                return View(new List<Post>());

            var cars = await _carSearchService.SearchByMakeAsync(make);
            var carIds = new List<int>();
            foreach (var car in cars)
                carIds.Add(car.Id);

            var posts = new List<Post>();
            foreach (var carId in carIds)
            {
                var postsForCar = await _postService.GetPostsByCarIdAsync(carId);
                posts.AddRange(postsForCar);
            }

            return View(posts);
        }

        [Authorize(Roles = "User, Admin")]
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,PostedOn,PersonId,CarId,PhoneNumber")] Post post, IFormFile coverPhoto)
        {
            if (ModelState.IsValid)
            {
                var created = await _postService.CreatePostAsync(post, coverPhoto);
                if (created)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", "Failed to create post.");
            }

            PopulateDropdowns(post);
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var post = await _postService.GetPostByIdAsync(id.Value);
            if (post == null) return NotFound();

            PopulateDropdowns(post);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,PostedOn,PersonId,CarId,PhoneNumber")] Post post)
        {
            if (id != post.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var updated = await _postService.UpdatePostAsync(post);
                if (updated)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", "Failed to update post.");
            }

            PopulateDropdowns(post);
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var post = await _postService.GetPostByIdAsync(id.Value);
            if (post == null) return NotFound();

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _postService.DeletePostAsync(id);
            if (!deleted) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropdowns(Post? post = null)
        {
            ViewData["CarId"] = new SelectList(_postService.GetAllCars(), "Id", "Make", post?.CarId);
            ViewData["CarModel"] = new SelectList(_postService.GetAllCars(), "Id", "Model", post?.CarId);
            ViewData["PersonId"] = new SelectList(_postService.GetAllPersons(), "Id", "Email", post?.PersonId);
        }
    }
}
