using Katas.TestDoubles.CharacterCopier;

namespace Tests.TestDoubles.CharacterCopier.V1;

public class DestinationSpy : IDestination
{
    private string _characters = "";
 
    public void SetChar(char c)
    {
        _characters += c;
    }

    internal string GetCharacters()
    {
        return _characters;
    }
}