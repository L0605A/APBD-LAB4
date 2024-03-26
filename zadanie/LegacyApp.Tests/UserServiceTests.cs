namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsTrueForValidData()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseForFirstNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(null, "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseForLastNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", null, "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        Action action = () => userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 100);
        
        //Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserHasNoCreditLimitExistsForUser()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        Action action = () => userService.AddUser("TEST", "TEST", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 100);
        
        //Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ReturnsFalseForMissingAtAndDotInEmail()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseForUnderageClient()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2020-03-21"), 1);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueForVIP()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 2);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueForImportantPerson()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 3);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueForNormalPerson()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ReturnsFalseForNormalPersonWithNoCreditLimit()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("John", "Kowalski", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        //Assert
        Assert.False(result);
    }
}