using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Process proc = Process.GetCurrentProcess();
        int pid = proc.Id;

        Console.WriteLine("Программа запущена.");
        Console.WriteLine($"Имя процесса: {proc.ProcessName}");
        Console.WriteLine($"PID: {pid}");
        Console.WriteLine("Открой Диспетчер задач, чтобы найти процесс, затем нажми Enter.");
        Console.ReadLine();

        proc.Refresh();
        long ramMb = proc.WorkingSet64 / (1024 * 1024);
        Console.WriteLine($"PID: {pid} | Память (WorkingSet): {ramMb} МБ");
        Console.WriteLine("Нажми Enter для запуска нагрузки на процессор...");
        Console.ReadLine();

        Console.WriteLine("Считаем (10 сек)...");
        Stopwatch sw = Stopwatch.StartNew();
        long total = 0;

        while (sw.Elapsed.TotalSeconds < 10)
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                total += (long)i * i;
            }
        }

        sw.Stop();
        Console.WriteLine($"Готово за {sw.ElapsedMilliseconds} мс, результат: {total}");
        Console.WriteLine("Нажми Enter для выхода.");
        Console.ReadLine();
    }
}