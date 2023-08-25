using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamManager.Helpers
{
    public class Logging
    {
        public static void Log(string log) =>
            File.AppendAllText("ChamsManager.log", $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] - {log}\n");
    }
}
