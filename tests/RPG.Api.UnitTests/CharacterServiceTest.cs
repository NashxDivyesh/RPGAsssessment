using RPG.Api.UnitTests.Helpers;
using rpgAPI.Model;
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
        Assert.True(result.Success);
        Assert.Equal("Ok", result.Message);
    }

    [Fact]
    public void GetCharacterByIdGivenValidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();
        var character = CharacterGenerator.GetValidCharacter();
        characterService.AddCharacter(character);

        //Act
        var result = characterService.GetCharacterById(character.Id);

        //Assert
        Assert.Equal(character, result.Data);
    }

    [Fact]
    public void GetCharacterByIdGivenInvalidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();

        //Act
        var result = characterService.GetCharacterById(2);

        //Assert
        Assert.False(result.Success);
        Assert.Equal("No character found", result.Message);
    }

    [Fact]
    public void AddCharacterGivenValidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();
        var character = CharacterGenerator.GetValidCharacter(); // Helper method to generate a valid character. Sometimes AutoFixture can be avoided for simplicity. Or if we want to test a specific scenario.

        //Act
        var result = characterService.AddCharacter(character);

        //Assert
        Assert.True(result.Data?.Contains(character));
        Assert.True(result.Success);
        Assert.Equal("Ok", result.Message);
    }

    [Fact]
    public void UpdateCharacterGivenValidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();
        var character = CharacterGenerator.GetValidCharacter();
        characterService.AddCharacter(character);

        //Act
        var result = characterService.UpdateCharacter(character);

        //Assert
        Assert.True(result.Data?.Contains(character));
        Assert.True(result.Success);
        Assert.Equal("Ok", result.Message);
    }

    [Fact]
    public void UpdateCharacterGivenInvalidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();

        //Act
        var result = characterService.UpdateCharacter(new Character { Id = 2 });

        //Assert
        Assert.False(result.Success);
        Assert.Equal("No character found", result.Message);
    }

    [Fact]
    public void DeleteCharacterByIdGivenValidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();
        var character = CharacterGenerator.GetValidCharacter();
        characterService.AddCharacter(character);

        //Act
        var result = characterService.DeleteCharacterById(character.Id);

        //Assert
        Assert.DoesNotContain(character, result.Data);
        Assert.True(result.Success);
        Assert.Equal("Ok", result.Message);
    }

    [Fact]
    public void DeleteCharacterByIdGivenInvalidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();

        //Act
        var result = characterService.DeleteCharacterById(id: 2);

        //Assert
        Assert.False(result.Success);
        Assert.Equal("No character found", result.Message);
    }
}