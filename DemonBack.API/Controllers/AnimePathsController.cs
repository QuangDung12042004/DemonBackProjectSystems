using DemonBack.Application.AnimePaths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemonBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AnimePathsController : ControllerBase
    {
        private readonly IAnimePathService _animePathService;
        public AnimePathsController(IAnimePathService animePathService)
        {
            _animePathService = animePathService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            var paths = await _animePathService.GetAllAsync(ct);
            return Ok(paths);
        }
        [HttpGet("{pathId:guid}/exercises")]
        public async Task<IActionResult> GetExercisesAsync(Guid pathId, CancellationToken ct)
        {
            var exercises = await _animePathService.GetExercisesAsync(pathId, ct);
            return Ok(exercises);
        }
    }
}
