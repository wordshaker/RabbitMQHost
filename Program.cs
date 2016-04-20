using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Host
{
    class Program
    {
        static void Main(string[] args)
        { 
            RabbitMqHost host = new RabbitMqHost(args[0], args[1]);
            Console.ReadKey();
            host.Dispose();
        }
    }

    internal class RabbitMqHost
    {
       private readonly Process _process;
        private string _rabbitMqTempPath;

        public RabbitMqHost(string name, string port)
        {
            CreateTempDirectory();

            var rabbitMqInstallationPath = Directory.GetDirectories(@"C:\Program Files (x86)\RabbitMQ Server\", "rabbitmq_server-*").OrderByDescending(x => x).First();

            var processStartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = Path.Combine(rabbitMqInstallationPath, "sbin", "rabbitmq-server.bat"),
                Arguments = "-detatched"
            };

            processStartInfo.EnvironmentVariables["RABBITMQ_NODENAME"] = name;
            processStartInfo.EnvironmentVariables["RABBITMQ_NODE_PORT"] = port;
            processStartInfo.EnvironmentVariables["RABBITMQ_BASE"] = _rabbitMqTempPath;
            processStartInfo.EnvironmentVariables["HOMEDRIVE"] = "Z:\\";
            processStartInfo.EnvironmentVariables["HOMEPATH"] = "";

            _process = Process.Start(processStartInfo);

          }

        public void Dispose()
        {
            if (_process != null && !_process.HasExited)
            {
                _process.CloseMainWindow();
            }
        }

        private void CreateTempDirectory()
        {
            _rabbitMqTempPath = Path.Combine($"{Path.GetTempPath()}\\{Path.GetRandomFileName()}", Path.GetRandomFileName());

            if (Directory.Exists(_rabbitMqTempPath))
            {
                Directory.Delete(_rabbitMqTempPath, true);
            }

            Directory.CreateDirectory(_rabbitMqTempPath);
        }
    }
}
