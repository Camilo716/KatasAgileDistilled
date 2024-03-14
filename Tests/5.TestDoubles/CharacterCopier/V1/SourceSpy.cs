using Katas.TestDoubles.CharacterCopier;

namespace Tests.TestDoubles.CharacterCopier.V1;

public class SourceSpy : ISource
{
    private const string _characters = "testCopier\n";
    private int _index = -1;

    public char GetChar()
    {
        _index++;
        return _characters[_index];
    }
}