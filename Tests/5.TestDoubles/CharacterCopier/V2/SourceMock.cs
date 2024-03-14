using Katas.TestDoubles.CharacterCopier;
using Moq;

namespace Tests.TestDoubles.CharacterCopier.V2;

public class SourceMock
{
    public static Mock<ISource> Get()
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
}