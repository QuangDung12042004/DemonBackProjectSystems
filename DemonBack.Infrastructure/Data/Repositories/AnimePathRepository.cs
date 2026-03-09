using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemonBack.Application.AnimePaths;
using DemonBack.Application.AnimePaths.Models;
using DemonBack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DemonBack.Infrastructure.Data.Repositories
{
    public sealed record AnimePathRepository : IAnimePathRepository
    {
        private readonly AppDbContext _dbContext;
        public AnimePathRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<AnimePathDto>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AnimePaths
                .AsNoTracking()
                .OrderBy(x => x.CharacterName)
                .Select(x => new AnimePathDto(x.Id, x.CharacterName, x.Description))
                .ToListAsync(ct);
        }

        public async Task<IReadOnlyList<AnimePathExerciseDto>> GetExercisesAsync(Guid pathId, CancellationToken ct = default)
        {
            return await _dbContext.PathExercises
            .AsNoTracking()
            .Where(pe => pe.PathId == pathId)
            .OrderBy(pe => pe.DayOfWeek).ThenBy(pe => pe.OrderIndex)
            .Select(pe => new AnimePathExerciseDto(
                pe.DayOfWeek,
                pe.OrderIndex,
                pe.ExerciseId,
                pe.Exercise != null ? pe.Exercise.Name : string.Empty,
                pe.RecommendedSets,
                pe.RecommendedReps,
                pe.RestSeconds
            ))
            .ToListAsync(ct);
        }
    }
}
