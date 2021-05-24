using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliker.Logic;

namespace Console
{
    using Cliker.Logic.ToolsForQuery;
    using Cliker.Logic.Utility;

    class Program
    {
        static void Main(string[] args)
        {
            using (var client = RequestWorker.GetClient())
            {
                WorkerUtils.CheckHealth(client);
            }
        }
    }
}
