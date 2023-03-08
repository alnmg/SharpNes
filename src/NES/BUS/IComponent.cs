namespace SharpNes.NES;

/// <summary>
/// IO interface for bus components
/// </summary>
public interface IComponent
{
    byte read(ushort address);
    void write(ushort address, byte value);
    bool IsReadOnly(int address);
    
}
