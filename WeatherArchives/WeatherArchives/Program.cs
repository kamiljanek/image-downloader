using Grpc.Core;
using Slack.Webhooks.Blocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace WeatherArchives
{
    class Program
    {

        static void Main(string[] args)
        {
            Values.Title();
            Menu.MainMenu();
        }

    }
}

