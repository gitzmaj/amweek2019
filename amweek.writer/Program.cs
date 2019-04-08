using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace amweek.writer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder();
            var writer = new Writer();
            writer.Subscribe();
            await hostBuilder.RunConsoleAsync();
        }
    }
}
