using System;
using System.Collections.Generic;
using System.Text;

namespace coinApp.Model
{
    public class Coin
    {
        public string Asset_id { get; set; }
        public string Name { get; set; }
        public float Price_usd { get; set; }
        public string Id_icon { get; set; }
        public string Icon_url { get; set; }
    }
}
