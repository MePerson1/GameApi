using AutoMapper;
using FirstWebApi.Dto;
using FirstWebApi.Interfaces;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public readonly IGameRepository _gameRepository;
        public readonly IMapper _mapper;
        public GamesController(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllGames()
        {
            var games = _mapper.Map<List<GameDto>>(_gameRepository.GetAll());
            return Ok(games);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetGamesById(int id) 
        { 
            var game = _mapper.Map<GameDto>(_gameRepository.GetById(id));
            if(game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }
        [HttpPost]
        public IActionResult CreateGame([FromBody]GameDto gameCreate)
        {
            var newGame = _mapper.Map<Game>(gameCreate);
            var id = _gameRepository.Create(newGame);
            return Created("/api/pizza/{id}", newGame);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateGame([FromRoute]int id,[FromBody]GameDto game)
        {
            var gameToUpdate = _mapper.Map<Game>(game);
            var isSuccess = _gameRepository.Update(id, gameToUpdate);
            if(!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteGame(int id)
        {
            var isSuccess = _gameRepository.Delete(id);
            if(!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
