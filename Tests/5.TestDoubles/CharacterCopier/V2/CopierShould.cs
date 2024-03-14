using Katas.TestDoubles.CharacterCopier;
using Moq;

namespace Tests.TestDoubles.CharacterCopier.V2;
public class CopierShould
{   
    [Fact]
    public void CopyValueFromSourceToDestination()
    {
        Mock<ISource> sourceMock = SourceMock.Get();
        Mock<IDestination> destinationMock = DestinationMock.Get();
        Copier copier = new(sourceMock.Object, destinationMock.Object);

        copier.Copy();
        
        destinationMock.Verify(d => 
            d.SetChar(It.IsAny<char>()),
            Times.Exactly(6));

        // How can I make this assertion type bespite GetCharacters is not in IDestination interface?
        // Assert.Equal("copier", destinationMock.GetCharacters());
    }
}