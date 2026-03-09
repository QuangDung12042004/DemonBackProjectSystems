using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Application.AnimePaths.Models
{
    public sealed record AnimePathExerciseDto
    (
        short DayOfWeek,
        int OrderIndex,
        Guid ExerciseId,
        string ExerciseName,
        int? RecommendedSets,
        int? RecommendedReps,
        int? RestSeconds
);
}
