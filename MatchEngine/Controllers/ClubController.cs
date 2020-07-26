using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchEngine.Database;
using MatchLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly ILogger<ClubController> _logger;

        public ClubController(ILogger<ClubController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (var dbContext = new MyDbContext())
            {
                var js = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                };
                var json = JsonConvert.SerializeObject(dbContext.Clubs, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]Club newClub)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Clubs.Add(newClub);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Club editClub)
        {
            using (var dbContext = new MyDbContext())
            {
                var club = dbContext.Clubs.SingleOrDefault(x => x.Id == editClub.Id);
                club.Displayname = editClub.Displayname;
                club.Name = editClub.Name;
                club.Shortname = editClub.Shortname;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Club deleteClub)
        {
            using (var dbContext = new MyDbContext())
            {
                var club = dbContext.Clubs.SingleOrDefault(x => x.Id == deleteClub.Id);
                dbContext.Clubs.Remove(club);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
    }
}
