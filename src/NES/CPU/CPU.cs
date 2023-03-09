namespace SharpNes.NES.CPU;

public class CPU
{
    private AddressBUS bus;
    public CPU(AddressBUS bus){
        this.bus = bus;
        System.Console.WriteLine("CPU initialized");
    }


    enum statusFlag{
        C = (1 << 0),
        Z = (1 << 1),
        I = (1 << 2),
        B = (1 << 4),
        U = (1 << 5),
        V = (1 << 6),
        N = (1 << 7)
    }
    byte WaitCycles;
    ushort pc;
    ushort opcode;

    byte sp;
    byte status;

    byte A;
    byte X;
    byte Y;

    public void clock(){
        reset();
        instructions[0].execute(this, instructions[0]);

    }

    void reset(){
            pc = 3;
    }
    void interruptRequest(){

    }
    void nonMaskableInterrupt(){

    }

Instruction[] instructions = new Instruction[]
{
    new Instruction{
        Name = "idk", Size = 1, Cycles = 2,
        AddressingMode = AddressingMode.Accumulator,

        execute = (CPU, Instruction, opcode) =>{
            CPU.pc ++;
            Instruction.Cycles ++;
            
            //do fancy math add sum bits blah lots of things
        }
    },
};


    byte fetch(){
        return 0;
    }



}
