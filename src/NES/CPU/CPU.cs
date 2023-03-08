namespace SharpNes.NES.CPU;

public class CPU
{
    private BUS bus;

    public CPU(BUS bus){
        this.bus = bus;
        System.Console.WriteLine("CPU initialized");
    }

}
