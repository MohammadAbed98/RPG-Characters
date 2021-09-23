using ASP.Dtos.Character;
using ASP.Models;
using ASP.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Controllers
{
    [ApiController] // Used to serve HTTP API responses
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        //private static list<character> characters = new list<character>
        //{
        //    new character() ,
        //    new character { id = 1 ,  name = "sam" }
        //};

        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService; // _ rather than this
        }

        [HttpGet]
        [Route("GetAll")]
        // or [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResopnse<List<AddCharacterDto>>> > Get()
        {
            return Ok(await _characterService.GetAllCharacters());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResopnse<GetCharacterDto>> > GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResopnse<List<AddCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
           
            return Ok(await _characterService.AddCharacter(newCharacter) );

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResopnse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(await _characterService.UpdateCharacter(updatedCharacter));

         }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResopnse<List<GetCharacterDto>>>> DeleteChharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);


        }
    }
}
