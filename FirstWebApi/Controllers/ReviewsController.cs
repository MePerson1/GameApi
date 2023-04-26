using AutoMapper;
using FirstWebApi.Dto;
using FirstWebApi.Interfaces;
using FirstWebApi.Models;
using FirstWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        public readonly IReviewRepository _reviewRepository;
        public readonly IGameRepository _gameRepository;
        public readonly IMapper _mapper;
        public ReviewsController(IReviewRepository reviewRepository, IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetAll());
            return Ok(reviews);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetReviewById(int id)
        {
            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetById(id));
            if (review is null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpPost]
        public IActionResult CreateReview([FromQuery] int gameId,[FromBody]CreateReviewDto review)
        {
            var newReview = _mapper.Map<Review>(review);
            newReview.Game = _gameRepository.GetById(gameId);
            newReview.Date = DateTime.Now;

            var id = _reviewRepository.Create(newReview);
            return Created("/api/Reviews/{id}", newReview);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateReview([FromRoute] int id, [FromBody] ReviewDto review)
        {
            var updateReview = _mapper.Map<Review>(review);
            var isSuccess = _reviewRepository.Update(id, updateReview);
            if (!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteReview(int id)
        {
            var isSuccess = _reviewRepository.Delete(id);
            if (!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
