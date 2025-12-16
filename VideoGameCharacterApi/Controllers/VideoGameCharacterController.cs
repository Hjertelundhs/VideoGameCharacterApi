using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameCharacterController : ControllerBase
{
    private static List<Character> characters = new List<Character>
    {
        new Character{Game = "Mario", Id = 1, Name = "Super Mario Bros", Role = "Hero"},
        new Character{Game = "Link", Id = 2, Name = "The Legend of Zelda", Role = "Hero"},
        new Character{Game = "Bowser", Id = 3, Name = "Super Mario Bros", Role = "Villain"},
    };
    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters()
           => await Task.FromResult(Ok(characters));
}