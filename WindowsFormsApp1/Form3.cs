using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3(string videoID)
        {
            //webView에 유튜브 url을 이용한 웹브라우저 팝업
            InitializeComponent();
            webView21.Source = new Uri("https://youtu.be/" + videoID);
        }
    }
}
