using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameCharacterController(IVideoGameCharacterService service) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
        => Ok(await service.GetAllCharactersAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacter(int id)
    {
        var character = await service.GetCharacterByIdAsync(id);
        return character is null ? NotFound("Character not found with given ID") : Ok(character);
    }
    [HttpPost]
    public async Task<ActionResult<CharacterResponse>> CreateCharacter(CreateCharacterRequest character)
    {
        var createdCharacter = await service.CreateCharacterAsync(character);
        return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
    {
        var updated = await service.UpdateCharacterAsync(id, character);
        return updated ? NoContent() : NotFound("Character not found with given ID");
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCharacter(int id)
    {
        var deleted = await service.DeleteCharacterAsync(id);
        return deleted ? NoContent() : NotFound("Character not found with given ID");
    }
}