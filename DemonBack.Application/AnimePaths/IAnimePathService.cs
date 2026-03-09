using DemonBack.Application.AnimePaths.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Application.AnimePaths
{
    public interface IAnimePathService
    {
        Task<IReadOnlyList<AnimePathDto>> GetAllAsync(CancellationToken ct = default);
        Task<IReadOnlyList<AnimePathExerciseDto>> GetExercisesAsync(Guid pathId, CancellationToken ct = default);
    }
}
