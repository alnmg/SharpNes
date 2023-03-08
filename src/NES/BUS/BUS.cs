namespace SharpNes.NES;
public class BUS
{
    CPU.CPU cpu;
    MEM.RAM ram;

    public BUS(){
        cpu = new CPU.CPU(this);
        ram = new MEM.RAM(this);

        //cpu is not added, it dont have adresses
        AddComponent(ram, 0x0000, 0x01ff);

        write(0x1, 0xff);
    }
    
    private Dictionary<ushort, IComponent> components = new Dictionary<ushort, IComponent>();

    public void AddComponent(IComponent component, ushort startAddress, ushort endAddress) {
        for (ushort address = startAddress; address <= endAddress; address++) {
            components[address] = component;
        }
    }

    public byte read(ushort address) {
        return components[address].read(address);
    }

    public void write(ushort address, byte value) {
        if (components[address].IsReadOnly(address)) {
            throw new InvalidOperationException("Cannot write to read-only address");
        }
        components[address].write(address, value);
    }

}
