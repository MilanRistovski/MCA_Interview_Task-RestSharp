using System;
using System.Collections.Generic;
using System.Text;

namespace Rest_Api_Task___RestSharp.Entities
{
    public class Product
    {
        public string name { get; set; }
        public bool domestic { get; set; }
        public double price { get; set; }
        public int? weight { get; set; }
        public string description { get; set; }
    }
}
