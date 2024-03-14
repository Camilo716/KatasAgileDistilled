using Katas.TestDoubles.CharacterCopier;
using Moq;

namespace Tests.TestDoubles.CharacterCopier.V2;

public class DestinationMock
{
    public static Mock<IDestination> Get()
    {
        Mock<IDestination> destinationMock = new();

        destinationMock.Setup(d => d.SetChar(It.IsAny<char>()));

        return destinationMock;
    } 
}