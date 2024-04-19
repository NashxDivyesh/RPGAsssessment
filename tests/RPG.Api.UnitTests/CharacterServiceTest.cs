using rpgAPI.Service;

namespace RPG.Api.UnitTests;

public class CharacterServiceTest
{
    [Fact]
    public void GetAllCharacterGivenValidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();

        //Act
        var result = characterService.GetAllCharacter();

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void AddCharacterGivenCalidRequestGetResult()
    {
        var character = new Character();
        
    }
}