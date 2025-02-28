using HtmlAgilityPack;
using System;

namespace WindowsFormsApp1
{
    internal class video
    {
        public string takeVideoId(string title, string singer) //유튜브 비디오 ID값 가져오는 함수
        {
            string urlCode = title + "-" + singer;
            string selectSongUrl = "https://www.google.com/search?q=" + urlCode + "&hl=ko&biw=813&bih=696&tbm=vid&sxsrf=";
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36";
            HtmlAgilityPack.HtmlDocument doc = web.Load(selectSongUrl);
            HtmlNode linkNode = doc.DocumentNode.SelectSingleNode("//div[@class='ct3b9e']/a");
            
            string videoIDBefore = linkNode.GetAttributeValue("href", "");
            char ch = '=';
            string result = videoIDBefore.Substring(videoIDBefore.LastIndexOf(ch));
            string videoID = result.Substring(1); 

            return videoID; 
        }

        public string takeSongId(string title, string singer) //(멜론 기준) 노래 ID값 가져오는 함수
        {
            string Song_url = "https://www.melon.com/search/song/index.htm?q="+ title + "&section=&searchGnbYn=Y&kkoSpl=N&kkoDpType=";
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.79 Safari/537.36";
            HtmlAgilityPack.HtmlDocument doc = web.Load(Song_url);

            HtmlNode idNode = doc.DocumentNode.SelectSingleNode("//*[@id='frm_defaultList']/div/table/tbody/tr[1]/td[3]/div/div/a[1]");
            string songIDBefore = idNode.GetAttributeValue("href", "");

            string temp = songIDBefore.Substring(songIDBefore.LastIndexOf("("));
            temp = temp.Substring(2);
            string[] songID = temp.Split('\'');

            return songID[0];
        }
    }
}
