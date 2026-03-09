using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Application.AnimePaths.Models
{
    public sealed record AnimePathDto
    ( 
        Guid Id,
        string CharacterName,
        string? Description
    );
}
