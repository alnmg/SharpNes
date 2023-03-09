namespace SharpNes.NES;

/// <summary>
/// IO interface for bus components
/// </summary>
public interface IComponent
{
    byte Read(ushort address);
    void Write(ushort address, byte value);
    bool IsReadOnly();
    
}
