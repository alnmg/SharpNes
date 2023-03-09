namespace SharpNes.NES.MEM;

public class RAM : IComponent
{
    private AddressBUS bus;
    public RAM(AddressBUS bus){
        this.bus = bus;
        System.Console.WriteLine("RAM initialized");
    }

    private byte[] memory = new byte[2048];

    public bool IsReadOnly()
    {
        return false;
    }

    public byte Read(ushort address)
    {
        return memory[address];
    }

    public void Write(ushort address, byte value)
    {
        memory[address] = value;
        //dump();
    }

    public void dump(){
        System.Console.WriteLine("\n           -=  RAM Memory HEX visualisation =-");
        
        System.Console.WriteLine("      | 00 | 01 | 02 | 03 | 04 | 05 | 06 | 07 | 08 | 09 | 0A | 0B | 0C | 0D | 0E | 0F | ");
        for(int addr = 0; addr < memory.Length; addr += 16){
           System.Console.WriteLine("${0:X4} | {1:X2} | {2:X2} | {3:X2} | {4:X2} | {5:X2} | {6:X2} | {7:X2} | "
           +"{8:X2} | {9:X2} | {10:X2} | {11:X2} | {12:X2} | {13:X2} | {14:X2} | {15:X2} | {16:X2} | ",
           addr, memory[addr],memory[addr +1], memory[addr +2],memory[addr +3],memory[addr+4], memory[addr +5],
           memory[addr+6],memory[addr+7],memory[addr+8],memory[addr+9],memory[addr+10],memory[addr+11],memory[addr+12],
           memory[addr+13],memory[addr+14], memory[addr+15]);
        }
    }
}
