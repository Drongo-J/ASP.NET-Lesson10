using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Dtos;
using WebApiDemo.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public static List<Player> Players { get; set; } = new List<Player>()
        {
            new Player()
            {
                 Id = 1,
                 City = "Baku",
                 PlayerName = "Leyla",
                 Score = 99
            },
            new Player()
            {
                 Id = 2,
                 City = "Zaqatala",
                 PlayerName = "Arif",
                 Score = 100
            },
            new Player()
            {
                 Id = 3,
                 City = "Gence",
                 PlayerName = "Tural",
                 Score = 89
            }
        };

        // GET: api/<PlayerController>
        [HttpGet]
        public IEnumerable<PlayerDto> Get()
        {
            var dataToReturn = Players.Select(x =>
            {
                return new PlayerDto()
                {
                    Id = x.Id,
                    PlayerName = x.PlayerName
                };
            });
            return dataToReturn;
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public PlayerDto Get(int id)
        {
            var player = Players.First(x => x.Id == id);
            if (player != null)
            {
                var dataToReturn = new PlayerDto()
                {
                    Id = player.Id,
                    PlayerName = player.PlayerName
                };
                return dataToReturn;
            }
            return null!;
        }

        // POST api/<PlayerController>
        [HttpPost]
        public IActionResult Post([FromBody] PlayerAddDto value)
        {
            try
            {
                var obj = new Player()
                {
                    PlayerName = value.PlayerName,
                    Score = value.Score,
                     City = value.City,
                      Id = 10
                };

                Players.Add(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlayerAddDto value)
        {
            try
            {
                var item = Players.FirstOrDefault(x => x.Id == id);
                if (item == null)
                    return NotFound();

                item.City = value.City;
                item.Score = value.Score;
                item.PlayerName = value.PlayerName;
                //Players.Update(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = Players.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                Players.Remove(item);
                return NoContent();
            }
            return NotFound();
        }
    }
}
