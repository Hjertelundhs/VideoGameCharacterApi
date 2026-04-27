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
}
