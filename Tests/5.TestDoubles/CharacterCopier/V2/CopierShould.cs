using Katas.TestDoubles.CharacterCopier;
using Moq;

namespace Tests.TestDoubles.CharacterCopier.V2;
public class CopierShould
{   
    [Fact]
    public void CopyValueFromSourceToDestination()
    {
        Mock<ISource> sourceMock = GetSourceMock();
        Mock<IDestination> destinationMock = GetDestinationMock();
        Copier copier = new(sourceMock.Object, destinationMock.Object);

        copier.Copy();
        
        destinationMock.Verify(d => 
            d.SetChar(It.IsAny<char>()),
            Times.Exactly(6));
        // How can I make this assertion type bespite GetCharacters is not in IDestination interface?
        // Assert.Equal("copier", destinationMock.GetCharacters());
    }

    private static Mock<ISource> GetSourceMock()
    {
        Mock<ISource> sourceMock = new();
        
        sourceMock.SetupSequence(s => s.GetChar())
            .Returns('c')
            .Returns('o')
            .Returns('p')
            .Returns('i')
            .Returns('e')
            .Returns('r')
            .Returns('\n');
        
        return sourceMock;
    }

    private static Mock<IDestination> GetDestinationMock()
    {
        Mock<IDestination> destinationMock = new();

        destinationMock.Setup(d => d.SetChar(It.IsAny<char>()));

        return destinationMock;
    }
}