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
    public partial class Form2 : Form // 처음 인트로 창
    {
        Image dudu;
        Image bdudu;

        MediaPlayer.MediaPlayerClass mp3player1 = new MediaPlayer.MediaPlayerClass();
        SoundPlayer bt1 = new SoundPlayer();
        SoundPlayer bt2 = new SoundPlayer();

        Form1 form1 = new Form1();  //게임하는 창

        Timer timer = new Timer();  //두더지 움직이게
        Random rand = new Random();  //스위치 중복 방지

        int r;

        bool bfir = false; //true가 되면 두더지 나타내는 불값
        bool bsec = false;
        bool bthi = false;

        public Form2()
        {
            InitializeComponent();
           this.Paint += Form2_Paint; 
            this.Load += Form2_Load;
       
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            DoubleBuffered = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dudu = Image.FromFile("두두.png");
            bdudu = Image.FromFile("폭탄두두.png");

            this.mp3player1.EnableContextMenu = true;
            this.mp3player1.FileName = @"C:\Lecture\_CSharp_\개인프젝\2019_08_19_개인프젝\2019_08_18_개인프젝\bin\Debug/인트로.mp3";
            bt1.SoundLocation = "버튼.wav";
            bt2.SoundLocation = "설명창.wav";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int prerand = r;
            r = rand.Next(3);

            while(true)   //스위치에 들어갈 난수 중복 방지
            {
                if(prerand==r)
                {
                    r = rand.Next(3);
                }
                else
                {
                    break;
                }
            }

            switch(r)
            {
                case 0:
                    bfir = true; //true 된 두더지 나옴
                    break;
                case 1:
                    bsec = true;
                    break;
                case 2:
                    bthi = true;
                    break;
             
            }
            Invalidate();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

           g.DrawImage(dudu, 220, 160, 190, 170); //계속 띄워져 있는 두더지
         
            if (bfir == true)
            {
                g.DrawImage(dudu, 15, 160, 190, 170);
                g.DrawImage(bdudu, 450, 280, 190, 170);
                bfir = false; //true 된 두더지 나오고 다시 false 만들어줌
            }

            if(bsec==true)
            {
                g.DrawImage(dudu, 15, 30, 190, 170);
                g.DrawImage(bdudu, 15, 280, 190, 170);
                bsec = false;
            }
               
            if(bthi==true)
            {
                g.DrawImage(dudu, 450, 30, 190, 170);
                g.DrawImage(bdudu, 220, 280, 190, 170);
                bthi = false;
            }

        }

        private void Btstart_Click(object sender, EventArgs e) //start 버튼 누르면
        {
            bt1.Play(); //버튼음
            this.Hide(); //폼2 숨김
            form1.Show(); //폼1(게임할 창) 보여줌
            mp3player1.Stop(); //폼2의 배경음악 끔
        }

        private void BtEnd_Click(object sender, EventArgs e)  //End 버튼 누르면
        {
            bt1.Play(); //버튼음
            this.Close(); //폼2 창 끔
        }

        private void 게임설명ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt2.Play(); // 설명창 뜨면 효과음나게
            Form3 fm3 = new Form3(); 
            fm3.Show(); //f3(겜 설명 창) 보여줌
        }
    }
}
