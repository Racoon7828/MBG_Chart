using HtmlAgilityPack;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Music
    {
        public ObjectId _id { get; set; }
        public string rank { get; set; }
        public int rank_int { get; set; }
        public string title { get; set; } 
        public string singer { get; set; }
    }
}
