using ASP.Data;
using ASP.Dtos.Character;
using ASP.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        //private static List<Character> dbCharacters = new List<Character>
        //{
        //    new Character() ,
        //    new Character { Id = 1 ,  Name = "Sam" }
        //};
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper , DataContext context)
        {
            _mapper = mapper;
            _context = context; // Initilize to DBContext
        }
        public async Task<ServiceResopnse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResopnse<List<GetCharacterDto>>() ;
            Character character = _mapper.Map<Character>(newCharacter);
            //character.Id = dbCharacters.Max(c => c.Id) + 1;
            //dbCharacters.Add(character);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            //serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

    
        public async Task<ServiceResopnse<List<GetCharacterDto>>> GetAllCharacters()
        { 
            var serviceResponse = new ServiceResopnse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResopnse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResopnse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            //serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacters.FirstOrDefault(c => c.Id == id) ) ;
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter) ;
            return serviceResponse;

        }

        public async Task<ServiceResopnse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResopnse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strngth = updatedCharacter.Strngth;
                character.Defense = updatedCharacter.Defense;
                character.Intellegence = updatedCharacter.Intellegence;
                character.Class = updatedCharacter.Class;
                Console.WriteLine(updatedCharacter.Class);

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(ArgumentNullException ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message ;
            }
            return serviceResponse;
        }

        public async Task<ServiceResopnse<List<GetCharacterDto>>> DeleteCharacter(int id)
            {
            var serviceResponse = new ServiceResopnse<List<GetCharacterDto>>();
            try
            {
                Character character = await _context.Characters.FirstAsync(c => c.Id == id);
                //dbCharacters.Remove(character);
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

       
    }
 


}
