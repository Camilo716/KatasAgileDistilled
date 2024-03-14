
namespace Katas.TestDoubles.CharacterCopier;

public class Copier
{
    private readonly ISource _source;
    private readonly IDestination _destination;

    public Copier(ISource source, IDestination destination)
    {
        _source = source;
        _destination = destination;
    }
    public void Copy()
    {
        char character = _source.GetChar();
        while(character != '\n')
        {
            _destination.SetChar(character);
            character = _source.GetChar();
        }
    }
}