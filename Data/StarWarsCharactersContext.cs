using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Characters.Models;

namespace StarWars.Characters.Data
{
    public class StarWarsCharactersContext : DbContext
    {
        public StarWarsCharactersContext (DbContextOptions<StarWarsCharactersContext> options)
            : base(options)
        {
        }

        public DbSet<StarWars.Characters.Models.Character> Character { get; set; } = default!;
    }
}
