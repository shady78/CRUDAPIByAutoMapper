using AutoMapper;
using CRUDAPI.Data;
using CRUDAPI.DTO;
using CRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BlogDbContext _context;
        private readonly IMapper _mapper;
        public PostController(BlogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _context.Posts.Include(c => c.Comments).ToList();
            var postDto = _mapper.Map<IList<PostDto>>(posts);
            return Ok(postDto);
        }
        [HttpGet("id:int", Name = "GetOnePostRoute")]
        public IActionResult Get(int id)
        {
            var post = _context.Posts.Include(c=> c.Comments).SingleOrDefault(p => p.Id == id);
            if (post is null)
            {
                return NotFound();
            }
            
            var postD = _mapper.Map<PostDto>(post);
            return Ok(postD);
        }

        [HttpPost]
        public IActionResult CreatePost(PostDto post)
        {
            var pos = _mapper.Map<Post>(post);
            _context.Posts.Add(pos);
            _context.SaveChanges();

            var url = Url.Link("GetOnePostRoute", new { post = post.Id });
            return Created(url!, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost([FromRoute]int id,[FromBody]PostDto post)
        {
            var postUpdate = _context.Posts.FirstOrDefault(p => p.Id == id);

            if (postUpdate is not null)
            {
                postUpdate.Title = post.Title;
                postUpdate.Content = post.Content;
                _context.SaveChanges();
            }
            else
            { 
                return BadRequest("Id in not valid");
            }

            var postDto = _mapper.Map<PostDto>(postUpdate);   
            return StatusCode(204, postUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post is null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
