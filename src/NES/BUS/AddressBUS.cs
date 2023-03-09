namespace SharpNes.NES
{
    public class AddressBUS
    {
        CPU.CPU cpu;
        MEM.RAM ram;
        public AddressBUS()
        {
            cpu = new CPU.CPU(this);
            ram = new MEM.RAM(this);
            
            //ram (and mirrors)
            
            AddComponent(new ComponentData{
                Component = ram,
                StartAddress = 0x0000,
                EndAddress = 0x0800
            });
            AddComponent(new ComponentData{
                Component = ram,
                StartAddress = 0x0800,
                EndAddress = 0x1000
            });
            AddComponent(new ComponentData{
                Component = ram,
                StartAddress = 0x1000,
                EndAddress = 0x1800
            });
            AddComponent(new ComponentData{
                Component = ram,
                StartAddress = 0x1800,
                EndAddress = 0x2000
            });


            cpu.clock();
        }

        private Dictionary<ushort, ComponentData> components = new Dictionary<ushort, ComponentData>();

        public void AddComponent(ComponentData component)
        {
            // Add a new component to the bus
           for(ushort address = component.StartAddress; address < component.EndAddress; address++ ){
                components.Add(address, component);
           }
        }

        public byte Read(ushort address)
        {
            return components[address].Component.Read(GetCorrectAddress(address));
        }

        public void Write(ushort address, byte value)
        {
            // Write a byte to the specified address on the bus

            if (components[address].Component.IsReadOnly())
            {
                throw new InvalidOperationException("Cannot write to read-only address");
            }
            components[address].Component.Write(GetCorrectAddress(address), value);
        }

        private ushort GetCorrectAddress(ushort address)
        {
                ComponentData component = components[address];

                ushort offset = (ushort)(address - component.StartAddress);

                return (ushort)(offset % (component.EndAddress - component.StartAddress));
        }

    }

    public struct ComponentData
    {
        public IComponent Component { get; set; }

        //relative to bus adress
        public ushort StartAddress { get; set;}
        public ushort EndAddress {get; set;}
    }
}
