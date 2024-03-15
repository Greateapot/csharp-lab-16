namespace Lab16Tests;

public class Lab16TestDumpLoaders
{
    [Fact]
    public void JsonDumpLoaderTest()
    {
        // arrange
        List<Person> people = [];
        people.AddRange(RandomPersonGenerator.GetRandomPersons(10));
        JsonDumpLoader<List<Person>> jsonDumpLoader = new();

        // act
        var result = jsonDumpLoader.Dump(people, "people.test.json");
        var news = jsonDumpLoader.Load("people.test.json");
        var error = jsonDumpLoader.Load("lol.test.json");

        // assert
        Assert.True(result);
        Assert.True(error is null);
        Assert.Equal(people, news);
    }

    [Fact]
    public void XmlDumpLoaderTest()
    {
        // arrange
        List<Person> people = [];
        people.AddRange(RandomPersonGenerator.GetRandomPersons(10));
        XmlDumpLoader<List<Person>> xmlDumpLoader = new();

        // act
        var result = xmlDumpLoader.Dump(people, "people.test.xml");
        var news = xmlDumpLoader.Load("people.test.xml");
        var error = xmlDumpLoader.Load("lol.test.xml");

        // assert
        Assert.True(result);
        Assert.True(error is null);
        Assert.Equal(people, news);
    }
}