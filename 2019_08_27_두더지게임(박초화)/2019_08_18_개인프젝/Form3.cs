using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2019_08_18_개인프젝
{
    public partial class Form3 : Form  //설명창
    {
        SoundPlayer bt3 = new SoundPlayer();
        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
            this.Text = "게임 설명서";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bt3.SoundLocation = "뿅.wav";
        }

        private void Btclose_Click(object sender, EventArgs e)
        {
            bt3.Play(); //버튼음
            this.Close(); //창닫기
        }
    }
}
