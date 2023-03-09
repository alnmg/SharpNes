namespace SharpNes.NES
{
    public class DataBUS
    {
        private List<ComponentData> components = new List<ComponentData>();

        CPU.CPU cpu;
        MEM.RAM ram;
        public DataBUS()
        {
            cpu = new CPU.CPU(this);
            ram = new MEM.RAM(this);
            
            //ram (and mirrors)
            components.Add(new ComponentData { 
                Component = ram, 
                StartAddress = 0x0000, 
                EndAddress = 0x1FFF, 
                Size = 0x0800 
            });
            components.Add(new ComponentData { 
                Component = ram, 
                StartAddress = 0x0800, 
                EndAddress = 0x0FFF, 
                Size = 0x0800 
            });
            components.Add(new ComponentData { 
                Component = ram, 
                StartAddress = 0x1000, 
                EndAddress = 0x17FF, 
                Size = 0x0800 
            });
            components.Add(new ComponentData { 
                Component = ram, 
                StartAddress = 0x1800, 
                EndAddress = 0x1FFF, 
                Size = 0x0800 
            });

         Write
        }

        public void AddComponent(IComponent component, ushort startAddress, ushort endAddress)
        {
            // Add a new component to the bus
            ushort size = (ushort)(endAddress - startAddress + 1);
            components.Add(new ComponentData { Component = component, StartAddress = startAddress, EndAddress = endAddress, Size = size });
        }

        public byte Read(ushort address)
        {
            // Read a byte from the specified address on the bus
            ushort componentAddress = (ushort)(address - GetStartAddress(address));
            return components[address].Component.read(componentAddress);
        }

        public void Write(ushort address, byte value)
        {
            // Write a byte to the specified address on the bus
            ushort componentAddress = (ushort)(address - GetStartAddress(address));
            if (components[GetComponentIndex(address)].Component.IsReadOnly(componentAddress))
            {
                throw new InvalidOperationException("Cannot write to read-only address");
            }
            components[address].Component.write(componentAddress, value);
        }

        private ushort GetStartAddress(ushort address)
        {
            // Get the start address of the component containing the specified address
            return components[GetComponentIndex(address)].StartAddress;
        }

        private int GetComponentIndex(ushort address)
        {
            // Get the index of the component containing the specified address
            for (int i = 0; i < components.Count; i++)
            {
                if (address >= components[i].StartAddress && address <= components[i].EndAddress)
                {
                    return i;
                }
            }
            throw new ArgumentOutOfRangeException($"No component found for address {address:X}");
        }
    }

    public class ComponentData
    {
        public IComponent Component { get; set; }
        public ushort StartAddress { get; set; }
        public ushort EndAddress { get; set; }
        public ushort Size { get; set; }
    }
}
