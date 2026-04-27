using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<CharacterResponse> CreateCharacterAsync(CreateCharacterRequest character)
        {
            var newCaracter = new Character()
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };
            context.Characters.Add(newCaracter);
            await context.SaveChangesAsync();
            return new CharacterResponse
            {
                Id = newCaracter.Id,
                Name = newCaracter.Name,
                Game = newCaracter.Game,
                Role = newCaracter.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);
            if (characterToDelete is null) return false;

            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync() => await context.Characters.Select(c => new CharacterResponse
        {   
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var characterToUpdate = await context.Characters.FindAsync(id);
                if (characterToUpdate is null) return false;

            characterToUpdate.Name = character.Name;
            characterToUpdate.Game = character.Game;
            characterToUpdate.Role = character.Role;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
