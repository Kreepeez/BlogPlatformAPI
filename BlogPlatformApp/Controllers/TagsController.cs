using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatformApp.Data;
using BlogPlatformApp.Models;
using BlogPlatformApp.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BlogPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly PostContext _context;
        private readonly IDataRepository<Tags> _repo;

        public TagsController(PostContext context, IDataRepository<Tags> dataRepository)
        {
            _context = context;
            _repo = dataRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagViewModel>>> GetTags()
        {
            var tags = await _repo.GetAllTags();
            return Ok(tags);
        }
    }

}
