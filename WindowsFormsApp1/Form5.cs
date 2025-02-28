using HtmlAgilityPack;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        MongoClient client = new MongoClient();
        IMongoDatabase db;
        IMongoCollection<Music> collection;
        List<string> chartRank = new List<string>();

        public Form5(string selectSongTitle)
        {
            InitializeComponent();

            //DB에 접속하여 각 DB당 선택한 노래가 있는지 찾고 그것을 차트에 보여주는 작업
            db = client.GetDatabase("Music");
            search("last",selectSongTitle);
            search("Melon", selectSongTitle);
            search("Bugs", selectSongTitle);
            search("Genie", selectSongTitle);

            chart1.Titles.Add("차트 현황");
            chart1.Series[0].LegendText = "순위";
            chart1.Series[0].Points.AddXY("통합", chartRank[0]);
            chart1.Series[0].Points.AddXY("멜론", chartRank[1]);
            chart1.Series[0].Points.AddXY("벅스", chartRank[2]);
            chart1.Series[0].Points.AddXY("지니", chartRank[3]);
            chart1.Series[0].Points[0].Label = chartRank[0];
            chart1.Series[0].Points[0].Color = Color.Gold;
            chart1.Series[0].Points[1].Label = chartRank[1];
            chart1.Series[0].Points[1].Color = Color.Green;
            chart1.Series[0].Points[2].Label = chartRank[2];
            chart1.Series[0].Points[2].Color = Color.Orange;
            chart1.Series[0].Points[3].Label = chartRank[3];
            chart1.Series[0].Points[3].Color = Color.SkyBlue;

        }

        private void search(string dbName, string selectSongTitle) //주어진 db에서 선택된 노래의 rank값을 list에 저장하는 함수
        {
            collection = db.GetCollection<Music>(dbName);
            List<Music> musics = collection.AsQueryable().ToList<Music>();
            Boolean check =false;
            for(int i=0; i<100; i++)
            {
                Music select = new Music
                {
                    title = musics[i].title,
                    rank= musics[i].rank
                };

                if(select.title== selectSongTitle)
                {
                    chartRank.Add(select.rank);
                    check= true;
                    break;
                }
            }
            if(check==false)
            {
                chartRank.Add("0");
            }
        }
    }
}
