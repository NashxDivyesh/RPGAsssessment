using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpgAPI.Model;

namespace rpgAPI.Service
{
    public interface ICharacterService
    {

        ServiceResponse<List<Character>> GetAllCharacter();

        ServiceResponse<List<Character>> AddCharacter(Character newCharacter);

        ServiceResponse<Character> GetCharacterById(int id);

        ServiceResponse<Character> UpdateCharacter(Character newCharacter);

        ServiceResponse<Character> DeleteCharacterById(int id);
        
    }
}