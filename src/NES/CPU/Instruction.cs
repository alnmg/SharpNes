namespace SharpNes.NES.CPU;

public struct Instruction
{
    public string Name { get; set; }
    public int Cycles { get; set; }
    public int Size { get; set; }
    public AddressingMode AddressingMode { get; set; }

    
    public Action<CPU, Instruction, ushort> execute {get; set;}
}
public enum AddressingMode{
    Accumulator,
    Absolute,
    AbsoluteX,
    AbsoluteY,
    Immediate,
    Implied,
    IndexedIndirect,
    Indirect,
    IndirectIndexed,
    Relative,
    ZeroPage,
    ZeroPageX,
    ZeroPageY
}
