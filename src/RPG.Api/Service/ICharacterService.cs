using rpgAPI.Model;

namespace rpgAPI.Service
{
    public interface ICharacterService
    {

        ServiceResponse<List<Character>> GetAllCharacter();

        ServiceResponse<List<Character>> AddCharacter(Character newCharacter);

        ServiceResponse<Character> GetCharacterById(int id);

        ServiceResponse<List<Character>> UpdateCharacter(Character newCharacter);

        ServiceResponse<List<Character>> DeleteCharacterById(int id);

    }
}