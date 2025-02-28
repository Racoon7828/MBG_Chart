using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4(string title, string singer)
        {
            InitializeComponent();

            //(멜론 기준) 노래 ID값을 가져와 그 노래 정보를 크롤링 하는 작업
            video takeSongID = new video();
            string songID = takeSongID.takeSongId(title, singer);

            string Melon_url = "https://www.melon.com/song/detail.htm?songId=" + songID;
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.79 Safari/537.36";
            HtmlAgilityPack.HtmlDocument doc = web.Load(Melon_url);

            HtmlNode imageNode = doc.DocumentNode.SelectSingleNode("//*[@id='downloadfrm']/div/div/div[1]/a/img");
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//*[@id='downloadfrm']/div/div/div[2]/div[1]/div[1]");
            HtmlNode singerNode = doc.DocumentNode.SelectSingleNode("//*[@id='downloadfrm']/div/div/div[2]/div[1]/div[2]/a[1]");
            HtmlNode albumNode = doc.DocumentNode.SelectSingleNode("//*[@id='downloadfrm']/div/div/div[2]/div[2]/dl/dd[1]/a");
            HtmlNode album_DateNode = doc.DocumentNode.SelectSingleNode("//*[@id='downloadfrm']/div/div/div[2]/div[2]/dl/dd[2]");
            HtmlNode lyrics = doc.DocumentNode.SelectSingleNode("//*[@id='d_video_summary']");


            string image = imageNode.GetAttributeValue("src", "");

            pictureBox1.Load(image);
            label1.Text = titleNode.InnerText.Replace("곡명", "").Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.");
            label2.Text = singerNode.InnerText.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.");
            label3.Text = albumNode.InnerText.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.");
            label4.Text = album_DateNode.InnerText.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.");
            textBox1.Text = lyrics.InnerHtml.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.").Replace("<br>","\r\n")
                .Replace("<!-- height:auto; 로 변경시, 확장됨 -->",label1.Text+ " 가사");
        }

 
    }
}
