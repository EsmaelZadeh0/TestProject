namespace ServerSide.Models;

public record struct ClientInfoModel(double CpuProccess,
                        double RamProccess, IEnumerable<int> Numbers);
