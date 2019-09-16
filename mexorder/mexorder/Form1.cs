using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;
using Serilog.Events;

namespace mexorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initLogging();
        }
        private void Output_Text(string text)
        {
            var output = string.Concat(new string[]
            {
                "[",
                DateTime.Now.ToString("HH時mm分ss秒"),
                "]\r\n",
                text,
                "\r\n"
            });
            Log.Information(output);
        }
        
        private void initLogging()
        {
            var executingDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var logPath = Path.Combine(executingDir, "logs", DateTime.UtcNow.ToString("MM-dd-yyyy") + ".log");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(logPath)
                .WriteTo.Console(LogEventLevel.Information)
                .CreateLogger();
        }
    }
}
