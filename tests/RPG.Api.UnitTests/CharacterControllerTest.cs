using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RPG.Api.UnitTests.Helpers;
using rpgAPI.Controller;
using rpgAPI.Model;
using rpgAPI.Service;

namespace RPG.Api.UnitTests;

public class CharacterControllerTest
{
    [Fact]
    public void GetCharacterGivenValidRequestGetSucessResponse()
    {
        //Arrange
        var serviceResponse = new ServiceResponse<List<Character>>()
        {
            Data = CharacterGenerator.GetValidCharacterList(),
            Success = true,
            Message = "Ok"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.GetAllCharacter()).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.GetCharacters();

        //Assert
        var okResult = result.Result as OkObjectResult;
        var response = okResult!.Value as ServiceResponse<List<Character>>;
        Assert.NotNull(okResult);
        Assert.Equal(1, response?.Data?.Count);
    }

    [Fact]
    public void GetCharacterByIdGivenValidRequestGetSucessResponse()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<Character>()
        {
            Data = character,
            Success = true,
            Message = "Ok"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.GetCharacterById(character.Id)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.GetId(character.Id);

        //Assert
        var okResult = result.Result as OkObjectResult;
        var response = okResult!.Value as ServiceResponse<Character>;
        Assert.NotNull(okResult);
        Assert.Equal(character, response?.Data);
    }

    [Fact]
    public void GetCharacterByIdGivenInvalidRequestReturnsNotFound()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<Character>()
        {
            Data = character,
            Success = false,
            Message = "No character found"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.GetCharacterById(character.Id)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.GetId(character.Id);

        //Assert
        var okResult = result.Result as NotFoundObjectResult;
        var response = okResult!.Value as ServiceResponse<Character>;
        Assert.NotNull(okResult);
        Assert.Equal("No character found", response?.Message);
    }

    [Fact]
    public void AddCharacterGivenValidRequestGetSucessResponse()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<List<Character>>()
        {
            Data = CharacterGenerator.GetValidCharacterList(),
            Success = true,
            Message = "Ok"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.AddCharacter(character)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.PostCharacter(character);

        //Assert
        var okResult = result.Result as OkObjectResult;
        var response = okResult!.Value as ServiceResponse<List<Character>>;
        Assert.NotNull(okResult);
        Assert.Equal(1, response?.Data?.Count);
    }

    [Fact]
    public void UpdateCharacterGivenValidRequestGetSucessResponse()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<List<Character>>()
        {
            Data = CharacterGenerator.GetValidCharacterList(),
            Success = true,
            Message = "Ok"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.UpdateCharacter(character)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.UpdateCharacter(character);

        //Assert
        var okResult = result.Result as OkObjectResult;
        var response = okResult!.Value as ServiceResponse<List<Character>>;
        Assert.NotNull(okResult);
        Assert.Equal(1, response?.Data?.Count);
    }

    [Fact]
    public void UpdateCharacterGivenInvalidRequestReturnsNotFound()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<List<Character>>()
        {
            Data = CharacterGenerator.GetValidCharacterList(),
            Success = false,
            Message = "No character found"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.UpdateCharacter(character)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.UpdateCharacter(character);

        //Assert
        var okResult = result.Result as NotFoundObjectResult;
        var response = okResult!.Value as ServiceResponse<List<Character>>;
        Assert.NotNull(okResult);
        Assert.Equal("No character found", response?.Message);
    }

    [Fact]
    public void DeleteCharacterGivenValidRequestGetSucessResponse()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<List<Character>>()
        {
            Data = CharacterGenerator.GetValidCharacterList(),
            Success = true,
            Message = "Ok"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.DeleteCharacterById(character.Id)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.DeleteCharacter(character.Id);

        //Assert
        var okResult = result.Result as OkObjectResult;
        var response = okResult!.Value as ServiceResponse<List<Character>>;
        Assert.NotNull(okResult);
        Assert.Equal(1, response?.Data?.Count);
    }

    [Fact]
    public void DeleteCharacterGivenInvalidRequestReturnsNotFound()
    {
        //Arrange
        var character = CharacterGenerator.GetValidCharacter();
        var serviceResponse = new ServiceResponse<List<Character>>()
        {
            Data = CharacterGenerator.GetValidCharacterList(),
            Success = false,
            Message = "No character found"
        };

        var mockCharacterService = new Mock<ICharacterService>();
        mockCharacterService.Setup(s => s.DeleteCharacterById(character.Id)).Returns(serviceResponse);

        var characterController = new CharacterController(mockCharacterService.Object);

        //Act
        var result = characterController.DeleteCharacter(character.Id);

        //Assert
        var okResult = result.Result as NotFoundObjectResult;
        var response = okResult!.Value as ServiceResponse<List<Character>>;
        Assert.NotNull(okResult);
        Assert.Equal("No character found", response?.Message);
    }

    
}