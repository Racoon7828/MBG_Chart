using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        DataTable dt = new DataTable();
        
        IMongoCollection<Music> collection;
        IMongoDatabase db;

        List<Music> MyLists;
        public Form2(IMongoDatabase db)
        {
            InitializeComponent();
            this.db = db;
            dt.Columns.Add("곡정보");
            dt.Columns.Add("가수");

            //dataGridView 정렬막기
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            collection = db.GetCollection<Music>("MyList");
            MyLists = collection.AsQueryable().ToList<Music>();
            Viewer(MyLists);
        }

        private void delBtn_Click(object sender, EventArgs e) //myList 데이터 삭제 버튼
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("노래를 선택해 주세요");
            }
            else
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                String title = (String)dataGridView1.Rows[rowIndex].Cells[0].Value;

                var filter = Builders<Music>.Filter.Eq("title", title);
                collection.DeleteOne(filter);

                MyLists = collection.AsQueryable().ToList<Music>();
                MessageBox.Show("성공적으로 삭제되었습니다.");
                Viewer(MyLists);
            }
        }

        private void showBtn_Click(object sender, EventArgs e) //myList 에서 선택한 노래 재생 
        { 
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("노래를 선택해 주세요");
            }
            else
            {
                video takeVideoID = new video();
                string title = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string singer = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                string videoID = takeVideoID.takeVideoId(title, singer);

                Form3 outForm = new Form3(videoID);
                outForm.Show();
            }
        }

        private void Viewer(List<Music> musics) //dataGridView에 보여주는 함수
        {
            dt.Rows.Clear();
            for (int i = 0; i < musics.Count; i++)
            {
                dt.Rows.Add(musics[i].title.Replace("&#39;", "'").Replace("amp;", ""), musics[i].singer);
            }
            dataGridView1.DataSource = dt;
        }

        private void updateBtn_Click(object sender, EventArgs e) //mylist 최신화
        {
            MyLists = collection.AsQueryable().ToList<Music>();
            Viewer(MyLists);
        }
    }
}
