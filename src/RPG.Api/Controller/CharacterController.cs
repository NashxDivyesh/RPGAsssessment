using Microsoft.AspNetCore.Mvc;
using rpgAPI.Model;
using rpgAPI.Service;


namespace rpgAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<Character>>> GetCharacters()
        {
            return Ok(_characterService.GetAllCharacter());
        }


        [HttpGet("id")]
        public ActionResult<ServiceResponse<Character>> GetId(int id)
        {

            var response = _characterService.GetCharacterById(id);

            if (!response.Success)
            {
                return NotFound(response); //Return 404 if character not found
            }

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ServiceResponse<List<Character>>> PostCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public ActionResult<ServiceResponse<List<Character>>> UpdateCharacter(Character newCharacter)
        {
            var response = _characterService.UpdateCharacter(newCharacter);

            if (!response.Success)
            {
                return NotFound(response); //Return 404 if character not found
            }

            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<ServiceResponse<List<Character>>> DeleteCharacter(int id)
        {
            var response = _characterService.DeleteCharacterById(id);

            if (!response.Success)
            {
                return NotFound(response); //Return 404 if character not found
            }


            return Ok(response);
        }
    }
}