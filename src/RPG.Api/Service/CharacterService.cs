using System.Collections.Generic;
using System.Linq;
using rpgAPI.Model;

namespace rpgAPI.Service
{
    public class CharacterService : ICharacterService
    {


        private static List<Character> _characterList = new List<Character>()
        {
            new Character(),
            new Character(){Name = "Gollum", Id = 1},
        };


        public ServiceResponse<List<Character>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = _characterList
            };
            return serviceResponse;
        }

        public ServiceResponse<List<Character>> AddCharacter(Character newCharacter)
        { 
             _characterList.Add(newCharacter);
            
            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = _characterList
            };
            return serviceResponse;

        }

        public ServiceResponse<Character> GetCharacterById(int id)
        {
            var character = _characterList.FirstOrDefault(c=>c.Id==id);

            var serviceResponse = new ServiceResponse<Character>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Id Doesn't Exist";

                return serviceResponse;
            }

            serviceResponse.Data = character;

            return serviceResponse;
        }

        public ServiceResponse<Character> UpdateCharacter(Character newCharacter)
        {
            var character = _characterList.FirstOrDefault(c=>c.Id==newCharacter.Id);

            var serviceResponse = new ServiceResponse<Character>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Id Doesn't Exist";

                return serviceResponse;
            }

            character.Name = newCharacter.Name;
            character.CharacterClass = newCharacter.CharacterClass;
            character.Strength = newCharacter.Strength;
            character.Defense = newCharacter.Defense;
            character.HitPoint = newCharacter.HitPoint;

            serviceResponse.Data = character;

            return serviceResponse;
        }

        public ServiceResponse<Character> DeleteCharacterById(int id)
        {

            var character = _characterList.FirstOrDefault(c=>c.Id==id);

            var serviceResponse = new ServiceResponse<Character>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Id Doesn't Exist";

                return serviceResponse;
            }

            _characterList.Remove(character);
            
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}