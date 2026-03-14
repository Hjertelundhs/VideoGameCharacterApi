using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {

        private static List<Character> characters = new List<Character>
    {
        new Character{Game = "Mario", Id = 1, Name = "Super Mario Bros", Role = "Hero"},
        new Character{Game = "Link", Id = 2, Name = "The Legend of Zelda", Role = "Hero"},
        new Character{Game = "Bowser", Id = 3, Name = "Super Mario Bros", Role = "Villain"},
    };
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync() => await Task.FromResult(characters);


        public Task<Character> GetCharacterByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
