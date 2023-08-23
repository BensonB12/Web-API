using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("[controller]")] //This is saying, hey, the url is meant to do the controller name: BoardGamesController but without 'controller'. So BoardGames
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly ILogger<BoardGamesController> _logger;

        public BoardGamesController(ILogger<BoardGamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBoardGames")] //This is a special atribute that 
        public IEnumerable<BoardGame> GetAll()
        {
            return new[]
            {
                new BoardGame
                {
                    Id = 1,
                    Name = "Axis & Allies",
                    Year = 1981
                },
                new BoardGame
                {
                    Id = 2,
                    Name = "Citadels",
                    Year = 2000
                },
                new BoardGame
                {
                    Id = 3,
                    Name = "Terraforming Mars",
                    Year = 2016
                }
            };

        }

        [HttpGet("favorite")]
        public IEnumerable<BoardGame> GetFavs()
        {
            return new[]
            {
                new BoardGame
                {
                    Id = 1,
                    Name = "Axis & Allies",
                    Year = 1981
                },
                new BoardGame
                {
                    Id = 2,
                    Name = "Citadels",
                    Year = 2000
                },
            };
        }
    }
}
