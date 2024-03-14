using Katas.TestDoubles.CharacterCopier;

namespace Tests.TestDoubles.CharacterCopier;
public class CopierShould
{   
    [Fact]
    public void TestName()
    {
        SourceSpy sourceSpy = new();
        DestinationSpy destinationSpy = new();
        Copier copier = new(sourceSpy, destinationSpy);
        
        copier.Copy();

        Assert.Equal("testCopier", destinationSpy.GetCharacters());
    }
}