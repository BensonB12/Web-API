using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System;
using Web_API.DTO;

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
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public RestDTO<BoardGame[]> Get()           
        {
            return new RestDTO<BoardGame[]>()       
            {
                Data = new BoardGame[] {
                    new BoardGame()
                {
                    Id = 1,
                        Name = "Axis & Allies",
                        Year = 1981
                    },
                    new BoardGame()
                {
                    Id = 2,
                        Name = "Citadels",
                        Year = 2000
                    },
                    new BoardGame()
                {
                    Id = 3,
                        Name = "Terraforming Mars",
                        Year = 2016
                    }
            },
                Links = new List<LinkDTO> {      
                    new LinkDTO(
                        Url.Action(null, "BoardGames", null, Request.Scheme)!,
                        "self",
                        "GET"),
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
