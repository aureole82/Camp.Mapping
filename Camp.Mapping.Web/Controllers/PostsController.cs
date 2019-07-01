using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Camp.Mapping.Data;
using Camp.Mapping.Data.Models;
using Camp.Mapping.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Camp.Mapping.Web.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts

                // HACK: Full join with author table just to display user name.
                .Include(model => model.Author)
                .OrderByDescending(model => model.Created)
                .ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var post = await _context.Posts

                // HACK: Full join with author table just to display user name.
                .Include(model => model.Author)
                .FirstOrDefaultAsync(model => model.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromServices] UserManager<UserModel> userManager,
            [Bind("Id,Subject,Body")] PostModel post)
        {
            if (ModelState.IsValid)
            {
                post.Created = DateTime.Now;
                post.Author = await userManager.GetUserAsync(User);
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PostViewModel>(postModel));
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostViewModel viewModel)
        {
            var model = await _context.Posts.FindAsync(id);
            if (model == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(viewModel);

            _context.Entry(model).CurrentValues.SetValues(viewModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts

                // HACK: Full join with author table just to display user name.
                .Include(model => model.Author)
                .FirstOrDefaultAsync(model => model.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(postModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}