using Katas.TestDoubles.CharacterCopier;

namespace Tests.TestDoubles.CharacterCopier;

public class SourceSpy : ISource
{
    private string _characters = "testCopier\n";
    public char GetChar()
    {
        char next = _characters[0];
        _characters = _characters.Substring(1, _characters.Length - 1);
        return next;
    }
}