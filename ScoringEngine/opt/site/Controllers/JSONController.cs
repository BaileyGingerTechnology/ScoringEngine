using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace site.Controllers
{
    public class Check
    {
        public string title;
        public string command;
        public string expected;
        public bool good;
    }

    public class JSONController
    {
        string currentScorePath = @"../wwwroot/js/current.json";

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(currentScorePath))
            {
                string json = r.ReadToEnd();
                List<Check> items = JsonConvert.DeserializeObject<List<Check>>(json);
            }
        }
    }
}