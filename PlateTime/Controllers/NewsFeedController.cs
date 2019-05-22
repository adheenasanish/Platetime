using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlateTimeApp.Models;

namespace PlateTimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly NewsFeedContext _context;

        public NewsFeedController(NewsFeedContext context)
        {
            _context = context;
        }

        public object Item { get; private set; }

        [HttpGet]
        public IEnumerable<NewsFeed> GetAll()
        {
            return _context.NewsFeeds.ToList();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetById(long id)
        {
            var item = _context.NewsFeeds.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            //return new ObjectResult(Item);
            return Ok(item);
        }

        [HttpGet]
        [Route("[action]/{newsDate}")]
        public IActionResult GetByDate(DateTime newsDate)
        {
            var item = _context.NewsFeeds.Where(t => t.NewsDate == newsDate).ToList();
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /*

        [HttpPost]
        public IActionResult Create([FromBody]NewsFeed newsFeed)
        {
            if (newsFeed.Description == null || newsFeed.Description == "")
            {
                return BadRequest();
            }
            _context.NewsFeeds.Add(newsFeed);
            _context.SaveChanges();
            return new ObjectResult(newsFeed);
        }

        [HttpPut]
        [Route("NewsEdit")]
        public IActionResult Update([FromBody]NewsFeed newsFeed)
        {
            var item = _context.NewsFeeds.Where(t => t.Id == newsFeed.Id).FirstOrDefault();
            if(item == null)
            {
                return NotFound();
            }
            else
            {
                item.Description = newsFeed.Description;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteById(long id)
        {
            var item = _context.NewsFeeds.FirstOrDefault(t => t.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            _context.NewsFeeds.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }*/

    }
}