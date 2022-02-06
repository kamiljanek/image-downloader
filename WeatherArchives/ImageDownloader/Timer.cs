using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    internal static class Timer
    {
        internal async static Task UseDelay()
        {
            await Task.Delay(3000);
        }
    }
}
