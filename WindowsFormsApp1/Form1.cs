using HtmlAgilityPack;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();

        MongoClient client = new MongoClient();
        IMongoDatabase db;
        IMongoCollection<Music> collection;

        //db에서 받아온 값을 List에 저장
        List<Music> melon_test;
        List<Music> bugs_test;
        List<Music> genie_test;
        List<Music> temp_test;
        List<Music> merge_test;

        public Form1()
        {
            InitializeComponent();

            dt.Columns.Add("순위");
            dt.Columns.Add("곡정보");
            dt.Columns.Add("가수");

            //dataGridView 정렬막기
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dataGridView1.Columns["순위"].Frozen = true;

            //시작시 기존db 삭제 이후 새로 크롤링하여 db저장
            client = new MongoClient();
            db = client.GetDatabase("Music");

            db.DropCollection("full");
            db.DropCollection("temp");
            db.DropCollection("last");
            Melon();
            Bugs();
            Genie();
            Merge();
        }

        private void IntegraBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "통합순위차트";
            Viewer(merge_test, 100);
        }

        private void MelonBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "멜론차트";
            Viewer(melon_test, melon_test.Count);
        }

        private void BugsBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "벅스차트";
            Viewer(bugs_test, bugs_test.Count);
        }

        private void GenieBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "지니차트";
            Viewer(genie_test, genie_test.Count);
        }

        private void MyListAddBtn_Click(object sender, EventArgs e) //myListDB에 추가하기
        {
            collection = db.GetCollection<Music>("MyList");

            if (dataGridView1.CurrentRow==null)
            {
                MessageBox.Show("노래를 선택해 주세요");
            }
            else
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                Music program = new Music
                {
                    rank = dt.Rows[rowIndex][0].ToString(),
                    title = dt.Rows[rowIndex][1].ToString(),
                    singer = dt.Rows[rowIndex][2].ToString()
                };
                collection.InsertOne(program);
                MessageBox.Show("노래가 추가되었습니다.");
            }
        }

        private void MyListOpenBtn_Click(object sender, EventArgs e) //db정보를 넘겨 mylist Form2로 보내기
        {
            Form2 outForm = new Form2(db);
            outForm.Show();
        }

        private void resetBtn_Click(object sender, EventArgs e) //데이터 테이블 전체 초기화 이후 다시 크롤링 해서 DB 저장하는 버튼
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = (dataGridView1.DataSource as DataTable).Clone();
            }
            db.DropCollection("full");
            db.DropCollection("temp");
            db.DropCollection("last");

            Melon();
            Bugs();
            Genie();
            Merge();
            MessageBox.Show("성공적으로 초기화 되었습니다.");
        }

        private void showVidBtn_Click(object sender, EventArgs e) //선택한 노래를 재생하는 버튼
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("노래를 선택해 주세요");
            }
            else
            {
                video takeVideoID = new video();
                string title = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string singer = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string videoID = takeVideoID.takeVideoId(title, singer);

                Form3 outForm = new Form3(videoID);
                outForm.Show();
            }
        }

        private void infoBtn_Click(object sender, EventArgs e) //선택한 노래의 정보를 보여주는 버튼
        {

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("노래를 선택해 주세요");
            }
            else
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                string title = dt.Rows[rowIndex][1].ToString();
                string singer = dt.Rows[rowIndex][2].ToString();

                Form4 outForm = new Form4(title, singer);
                outForm.Show();
            }
        }

        private void chartBtn_Click(object sender, EventArgs e) //선택한 노래의 통합 및 3사 순위표를 차트로 보여주는 버튼
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("노래를 선택해 주세요");
            }
            else
            {
                string selectSongTitle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Form5 outForm = new Form5(selectSongTitle);
                outForm.Show();
            }

        }

        private void Melon() //멜론크롤링
        {
            string Melon_url = "https://www.melon.com/chart/index.htm";
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.79 Safari/537.36";
            HtmlAgilityPack.HtmlDocument doc = web.Load(Melon_url);

            HtmlNodeCollection rankNode = doc.DocumentNode.SelectNodes("//td/div[@class='wrap t_center']/span[1]");
            HtmlNodeCollection titleNode = doc.DocumentNode.SelectNodes("//div[@class='ellipsis rank01']/span/a");
            HtmlNodeCollection singerNode = doc.DocumentNode.SelectNodes("//div[@class='ellipsis rank02']/span[@class='checkEllipsis']");

            db.DropCollection("Melon");
            Add_db("Melon", rankNode, titleNode, singerNode);

            melon_test = collection.AsQueryable().ToList<Music>(); //크롤링한 결과를 melon_test에 저장
        }
        private void Bugs() //벅스 크롤링
        {
            string Bugs_url = "https://music.bugs.co.kr/chart/track/realtime/total?wl_ref=M_contents_03_01";
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.79 Safari/537.36";
            HtmlAgilityPack.HtmlDocument doc = web.Load(Bugs_url);

            HtmlNodeCollection rankNode = doc.DocumentNode.SelectNodes("//div[@class='ranking']/strong");
            HtmlNodeCollection titleNode = doc.DocumentNode.SelectNodes("//p[@class='title']/a");
            HtmlNodeCollection singerNode = doc.DocumentNode.SelectNodes("//p[@class='artist']/a[1]");

            db.DropCollection("Bugs");
            Add_db("Bugs", rankNode, titleNode, singerNode);

            bugs_test = collection.AsQueryable().ToList<Music>(); //크롤링한 결과를 bugs_test 저장
        }

        private void Genie() //지니 크롤링
        {
            db.DropCollection("Genie");
            for (int i = 1; i <= 2; i++)
            {
                string Bugs_url = "https://www.genie.co.kr/chart/top200?ditc=D&ymd=20221204&hh=01&rtm=Y&pg=" + i;
                HtmlWeb web = new HtmlWeb();
                web.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.79 Safari/537.36";
                HtmlAgilityPack.HtmlDocument doc = web.Load(Bugs_url);


                HtmlNodeCollection ranknode = doc.DocumentNode.SelectNodes("//td[@class='number']");
                HtmlNodeCollection titleNode = doc.DocumentNode.SelectNodes("//a[@class='title ellipsis']");
                HtmlNodeCollection singerNode = doc.DocumentNode.SelectNodes("//tbody/tr[@class='list']/td[@class='info']/a[2]");

                Add_db("Genie", ranknode, titleNode, singerNode);

                genie_test = collection.AsQueryable().ToList<Music>(); //크롤링한 결과를 genie_test 저장
            }
        }

        private void Viewer(List<Music> musics, int count) //dataGridView1에 보여주기위한 함수
        {
            dt.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                dt.Rows.Add(i + 1, musics[i].title.Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD."), musics[i].singer.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("#", ""));
            }

            dataGridView1.DataSource = dt;
        }

        private void Add_db(String platform, HtmlNodeCollection rankNode, HtmlNodeCollection titleNode, HtmlNodeCollection singerNode) //DB에 저장하기위한 함수
        {
            collection = db.GetCollection<Music>(platform);

            for (int i = 0; i < titleNode.Count; i++)
            {
                if (rankNode[i].InnerText.Length > 5)
                {
                    Music platform_music = new Music
                    {
                        rank = rankNode[i].InnerText.ToString().Substring(0,5).Trim(),
                        title = titleNode[i].InnerText.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.").ToUpper(),
                        singer = singerNode[i].InnerText,
                    };
                    collection.InsertOne(platform_music);
                }
                else
                {
                    Music platform_music = new Music
                    {
                        rank = rankNode[i].InnerText.ToString(),
                        title = titleNode[i].InnerText.Trim().Replace("&#39;", "'").Replace("amp;", "").Replace("PROD. BY", "PROD.").ToUpper(),
                        singer = singerNode[i].InnerText,
                    };
                    collection.InsertOne(platform_music);
                }
            }
        }

        private void full_db(List<Music> musics1, List<Music> musics2) //두개의 리스트를 하나의 리스트로 합치는 함수
        {
            db.DropCollection("full");
            collection = db.GetCollection<Music>("full");

            for (int i = 0; i < musics1.Count; i++)
            {

                if (musics1[i].rank.Length < 5) // if를 사용한 이유는 genie_test의 rank가 ex) 1               상승 이렇게 되어있기때문에 
                {                               // 그것을 제거하기 위함 if를 사용하지않으면 melon_test나 genie_test 같은경우 SubString 오류남
                    Music musics1_full = new Music
                    {
                        rank = musics1[i].rank.Trim(),
                        title = musics1[i].title.ToUpper().Replace("PROD. BY", "PROD.").Replace("&#39;", "'").Replace("amp;", ""),
                        singer = musics1[i].singer.ToUpper()
                    };
                    collection.InsertOne(musics1_full);
                }
                else
                {
                    Music musics1_full = new Music
                    {
                        rank = musics1[i].rank.Substring(0, 5).Trim(),
                        title = musics1[i].title.ToUpper().Replace("PROD. BY", "PROD.").Replace("&#39;", "'").Replace("amp;", ""),
                        singer = musics1[i].singer.ToUpper()
                    };
                    collection.InsertOne(musics1_full);
                }
            }

            for (int i = 0; i < musics2.Count; i++)
            {
                Music musics2_full = new Music
                {
                    rank = musics2[i].rank,
                    title = musics2[i].title.ToUpper().Replace("PROD. BY", "PROD.").Replace("&#39;", "'").Replace("amp;", ""),
                    singer = musics2[i].singer.ToUpper()
                };
                collection.InsertOne(musics2_full);
            }
        }

        private void distinct() //full_db함수를 사용하여 나온 하나의 통합리스트의 중복을 제거하는 함수
        {
            db.DropCollection("temp");
            collection = db.GetCollection<Music>("full");
            List<Music> musics = collection.AsQueryable().ToList<Music>();
            List<ObjectId> del_ID = new List<ObjectId>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 100; j < musics.Count; j++)
                {

                    if (musics[i].title == musics[j].title)
                    {
                        del_ID.Add(musics[i]._id);
                        del_ID.Add(musics[j]._id);

                        int a = int.Parse(musics[i].rank);
                        int b = int.Parse(musics[j].rank);

                        int add = (a + b) / 2;
                        string temp_rank = add.ToString();

                        Music temp = new Music
                        {
                            rank = temp_rank,
                            title = musics[i].title,
                            singer = musics[i].singer,
                        };
                        collection = db.GetCollection<Music>("temp");
                        collection.InsertOne(temp);
                        collection = db.GetCollection<Music>("full");
                    }
                }
            }

            for (int i = 0; i < del_ID.Count; i++)
            {
                var filter = Builders<Music>.Filter.Eq("_id", del_ID[i]);
                collection.DeleteOne(filter);
            }

            musics = collection.AsQueryable().ToList<Music>();

            for (int i = 0; i < musics.Count; i++)
            {
                Music temp2 = new Music
                {
                    rank = musics[i].rank,
                    title = musics[i].title,
                    singer = musics[i].singer,
                };
                collection = db.GetCollection<Music>("temp");
                collection.InsertOne(temp2);
                collection = db.GetCollection<Music>("full");
            }

            collection = db.GetCollection<Music>("temp");
            temp_test = collection.AsQueryable().ToList<Music>();
        }

        private void Merge() //통합순위db에 rank를 제대로 다시 할당하는 함수 ->최종 통합순위 db라고 보면됨
        {
            full_db(melon_test, bugs_test);
            distinct();

            full_db(genie_test, temp_test);
            distinct();

            int temp_rank;

            collection = db.GetCollection<Music>("temp");
            List<Music> musics = collection.AsQueryable().OrderBy(x => x.rank).ToList();
            db.DropCollection("last");
            collection = db.GetCollection<Music>("last");

            for (int i = 0; i < musics.Count; i++)
            {
                temp_rank = int.Parse(musics[i].rank);

                Music temp = new Music
                {
                    rank_int = temp_rank,
                    title = musics[i].title.ToUpper(),
                    singer = musics[i].singer.ToUpper()
                };
                collection.InsertOne(temp);
            }

            musics = collection.AsQueryable().OrderBy(x => x.rank_int).ToList();
            db.DropCollection("last");
            collection = db.GetCollection<Music>("last");
            for (int i = 0; i < 100; i++)
            {
                Music lastSort = new Music
                {
                    rank = (i + 1).ToString(),
                    title = musics[i].title.ToUpper(),
                    singer = musics[i].singer.ToUpper()
                };
                collection.InsertOne(lastSort);
            }

            merge_test = collection.AsQueryable().ToList<Music>();
        }
    }
}

