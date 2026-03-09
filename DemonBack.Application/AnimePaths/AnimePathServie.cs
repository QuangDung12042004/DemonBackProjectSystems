using DemonBack.Application.AnimePaths.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Application.AnimePaths
{
    public sealed record AnimePathServie : IAnimePathService
    {
        private readonly IAnimePathRepository _repo;
        public AnimePathServie(IAnimePathRepository repo)
        {
            _repo = repo;
        }
        public Task<IReadOnlyList<AnimePathDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

        public Task<IReadOnlyList<AnimePathExerciseDto>> GetExercisesAsync(Guid pathId, CancellationToken ct = default)
        => _repo.GetExercisesAsync(pathId, ct);
    }
}
