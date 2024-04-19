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
        public ActionResult<ServiceResponse<List<Character>>> GetCharacter()
        {
           return Ok(_characterService.GetAllCharacter());
        }


        [HttpGet("id")]
        public ActionResult<ServiceResponse<Character>> GetId(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<ServiceResponse<List<Character>>> PostCharacter(Character  newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        } 

        [HttpPut]
        public ActionResult<ServiceResponse<Character>> UpdateCharacter(Character newCharacter){
            return Ok(_characterService.UpdateCharacter(newCharacter));
        }     

        [HttpDelete]
        public ActionResult<ServiceResponse<Character>> DeleteCharacter(int id){
            return Ok(_characterService.DeleteCharacterById(id));
        }
    }
}