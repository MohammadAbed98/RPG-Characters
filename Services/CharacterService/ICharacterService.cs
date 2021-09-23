using ASP.Dtos.Character;
using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Services.CharacterService
{
    public interface ICharacterService
    {
        //Task<ServiceResopnse<List<Character>>> GetAllCharacters();
        Task<ServiceResopnse<List<GetCharacterDto>>> GetAllCharacters();
        //Task<ServiceResopnse<Character>> GetCharacterById(int id);
        Task<ServiceResopnse<GetCharacterDto>> GetCharacterById(int id);
        //Task<ServiceResopnse<List<Character>>> AddCharacter(Character newCharacter);
        Task<ServiceResopnse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResopnse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto newCharacter);
        Task<ServiceResopnse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}
