namespace Lab16Tests;

public class Lab16TestQueries
{
    private static Person p1 = new("1", "1", 1);
    private static Person p2 = new("2", "2", 2);
    private static Person p3 = new("3", "3", 3);
    private static Person p4 = new("4", "4", 4);

    [Fact]
    public void GetPersonsWithAgeGreaterThanTest()
    {
        // arrange

        List<Person> people = [p1, p2, p3, p4];
        List<Person> excepted = [p3, p4];

        // act
        var actual = people.GetPersonsWithAgeGreaterThan(2);

        // assert
        Assert.Equal(excepted, actual);
    }


    [Fact]
    public void SortByAgeTest()
    {
        // arrange

        List<Person> people = [p4, p1, p3, p2];
        List<Person> excepted = [p1, p2, p3, p4];

        // act
        people.SortByAge();

        // assert
        Assert.Equal(excepted, people);
    }


    [Fact]
    public void SortByLastNameTest()
    {
        // arrange

        List<Person> people = [p3, p2, p4, p1];
        List<Person> excepted = [p1, p2, p3, p4];

        // act
        people.SortByLastName();

        // assert
        Assert.Equal(excepted, people);
    }


    [Fact]
    public void SortByKeyTest()
    {
        // arrange
        List<Person> people = [p2, p4, p3, p1];
        List<Person> excepted = [p1, p2, p3, p4];

        // act
        people.SortByKey();

        // assert
        Assert.Equal(excepted, people);
    }

}
