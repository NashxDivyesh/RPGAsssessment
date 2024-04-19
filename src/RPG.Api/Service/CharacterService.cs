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

            serviceResponse.Success = true;
            serviceResponse.Message = "Ok";
            return serviceResponse;
        }

        public ServiceResponse<List<Character>> AddCharacter(Character newCharacter)
        {
            _characterList.Add(newCharacter);

            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = _characterList,
                Success = true,
                Message = "Ok"
            };
            return serviceResponse;

        }

        public ServiceResponse<Character> GetCharacterById(int id)
        {
            var character = _characterList.FirstOrDefault(c => c.Id == id);

            var serviceResponse = new ServiceResponse<Character>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No character found";

                return serviceResponse;
            }

            serviceResponse.Success = true;
            serviceResponse.Message = "Ok";
            serviceResponse.Data = character;

            return serviceResponse;
        }

        public ServiceResponse<List<Character>> UpdateCharacter(Character newCharacter)
        {
            var character = _characterList.FirstOrDefault(c => c.Id == newCharacter.Id);

            var serviceResponse = new ServiceResponse<List<Character>>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No character found";
                return serviceResponse;
            }
            _characterList.RemoveAll(c => c.Id == newCharacter.Id);
            _characterList.Add(newCharacter);

            serviceResponse.Success = true;
            serviceResponse.Message = "Ok";
            serviceResponse.Data = _characterList;

            return serviceResponse;
        }

        public ServiceResponse<List<Character>> DeleteCharacterById(int id)
        {

            var character = _characterList.FirstOrDefault(c => c.Id == id);

            var serviceResponse = new ServiceResponse<List<Character>>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No character found";

                return serviceResponse;
            }
            _characterList.RemoveAll(c => c.Id == id);

            serviceResponse.Success = true;
            serviceResponse.Message = "Ok";
            serviceResponse.Data = _characterList;

            return serviceResponse;
        }
    }
}