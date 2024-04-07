using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    //Arrange
    private UserService userService = new UserService();

    [Fact]
    public void ShouldReturnFalseWhenMissingFirstName()
    { 
        //Act
        var result = userService.AddUser(null, "Kowalski", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnFalseWhenMissingLastName()
    {
        //Act
        var result = userService.AddUser("Jan", null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnFalseWhenMissingAtSignInEmail()
    {
        //Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalskiwp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnFalseWhenMissingAtDotInEmail()
    {
        //Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@wppl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ShouldReturnFalseWhenYoungerThen21YearsOld()
    {
        //Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);

        //Assert
        Assert.False(result);
    }
    [Fact]
    public void ShouldReturnFalseWhenUserHasCreditLimitLesstThan500()
    {
        //Act
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUserDoesNotExist()
    {
        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            bool doesExist = userService.AddUser("Zubeyr", "Yavas", "kowalski@wp.pl", new DateTime(1997, 9, 11), 31);
        });
    }
    
}