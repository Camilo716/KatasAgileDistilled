using Katas.TestDoubles.CharacterCopier;

namespace Tests.TestDoubles.CharacterCopier.V1;
public class CopierShould
{   
    [Fact]
    public void CopyValueFromSourceToDestination()
    {
        SourceSpy sourceSpy = new();
        DestinationSpy destinationSpy = new();
        Copier copier = new(sourceSpy, destinationSpy);
        
        copier.Copy();

        Assert.Equal("testCopier", destinationSpy.GetCharacters());
    }
}