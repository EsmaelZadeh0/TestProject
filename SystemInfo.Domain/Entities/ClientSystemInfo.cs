using System.ComponentModel.DataAnnotations;

namespace SystemInfo.Domain.Entities;

public class ClientSystemInfo(double cpuProcess, double ramProcess, int numbersSum)
{
    [Key]
    public Guid Id { get; private set; }
    public double CpuProcess { get; private set; } = cpuProcess;
    public double RamProcess { get; private set; } = ramProcess;
    public int NumbersSum { get; private set; } = numbersSum;
}
