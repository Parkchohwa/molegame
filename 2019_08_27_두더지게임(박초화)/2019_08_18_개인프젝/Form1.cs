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
    public partial class Form1 : Form   // 게임하는 창
    {
        Image mole;   //사진
        Image sickmole;
        Image map;
        Image hammer;
        Image hithammer;
        Image bumpmole;
        Image burnmole;

        SoundPlayer bt = new SoundPlayer();   //음악
        SoundPlayer ham = new SoundPlayer();
        SoundPlayer hitting = new SoundPlayer();
        SoundPlayer burn = new SoundPlayer();
        SoundPlayer win = new SoundPlayer();
        SoundPlayer lose = new SoundPlayer();
        MediaPlayer.MediaPlayerClass mp3player = new MediaPlayer.MediaPlayerClass();

        Rectangle[,] rec = new Rectangle[3, 3]; //두더지 영역 사각형
        bool[,] btouch = new bool[3, 3]; //두더지 터치했으면 true->아픈두더지
        bool[,] bmole = new bool[3, 3]; // true-> 일반 두더지
        bool[,] bbump = new bool[3,3]; // true-> 폭탄 두더지
        bool[,] bburn = new bool[3, 3]; //폭탄 두더지 클릭했으면 true->터진두더지

        int recx = 20, recy = 75;   //사각형 틀 위치 크기 값
        int gap = 10;
        int recw = 130, rech = 130;

        int hamx;            //망치 위치는 계속 마우스를 따라다님
        int hamy;
       bool bhammer = false;  //false-> 원래망치 , true->내려간 망치

        Timer timer = new Timer();
        Random rand = new Random();

        int hit;
        int miss;
        int r;

        public Form1()
        {
            InitializeComponent();

            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
          this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
    
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;

            makeRec(); // 사각형 배열 만든 함수
            this.Load += Form1_Load;
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mole = Image.FromFile("두두.png");     //그림
            sickmole = Image.FromFile("맞은두두.png");
            map = Image.FromFile("맵1.jpg");
            hammer = Image.FromFile("망치.png");
            hithammer = Image.FromFile("때리는망치.png");
            bumpmole = Image.FromFile("폭탄두두.png");
            burnmole = Image.FromFile("폭발두두.png");
  
            bt.SoundLocation = "뿅.wav";   //wav 음악파일
            ham.SoundLocation = "망치.wav";
            hitting.SoundLocation = "맞을때.wav";
            burn.SoundLocation = "폭발소리.wav";
            win.SoundLocation ="성공.wav";
            lose.SoundLocation ="실패.wav";
            
            this.mp3player.EnableContextMenu = true;  //mp3 음악파일
            this.mp3player.FileName = @"C:\Lecture\_CSharp_\개인프젝\2019_08_19_개인프젝\2019_08_18_개인프젝\bin\Debug/배경음악.mp3";
            mp3player.Stop(); //mp3 로드되면 음악 바로 재생되서 스탑 걸어줌

            lbHit.Text = "Hit: " + hit;      //점수 화면에 보여지는 것
            lbMiss.Text = "Miss: " + miss;
            MessageBox.Show("두더지 잡기 시작할까요?","Are you Ready?"
                ,MessageBoxButtons.OK); 
            //바로 시작되서 메세지박스 넣어서 확인 누르면 타이머,음악 스타트됌
            mp3player.Play();
            timer.Start(); // 폼 띄우면 타이머 시작
                        //(enable true 하면 창이 뜨기전에 두더지가 나와있어서)
            Cursor.Hide(); //타이머 시작되면 커서 숨기기
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bmole[i,j] == true)   // 놓친 두더지 있으면
                    {
                        bmole[i, j] = false;  //놓친 두더지 스위치 문 전에 없애주기
                        miss++;             //두더지 놓쳤으면 miss 증가
                    }
                    if (bburn[i, j] == true)   // 폭탄맞은 두더지 있으면
                    {
                        bburn[i, j] = false; //폭탄두더지 스위치 문 전에 없애주기  
                    }

                    if (btouch[i, j] == true || bbump[i,j]==true)  // 맞은 두더지||폭탄두더지 있으면
                    {
                        btouch[i, j] = false;  // 스위치 전에 맞은 두더지 없애기
                        bbump[i, j] = false; //스위치 전에 폭탄 두더지 없애기
                    }

                }
            }
            lbMiss.Text = "Miss: " + miss;   //놓친 두더지 miss 증가되고 점수 올라간거 보여줌
        

            if(miss>=20)        // miss 20 이상 이면 게임끝
            {
                mp3player.Stop();   //음악 스탑
                timer.Stop();      //타이머 스탑
                lose.Play();     //졌을 때 뜨는 메세지 

                Cursor.Show(); //메세지 박스 전 커서 생기기
                MessageBox.Show("당신이 졌습니다", "You Lose");
                
              this.Close();             //창 닫음
                Application.Restart();  //첫번째 창으로 돌아감
             

            }
            else if(hit>=30)    // hist 30 이상 이면 게임 끝
            {
                mp3player.Stop();
                timer.Stop();
                win.Play();

                Cursor.Show();  //메세지 박스 전 커서 생기기
                MessageBox.Show("당신이 이겼습니다", "You Win");
               
                this.Close();
                Application.Restart();
            }


            int prerand = r;   // 랜덤 값 중복 방지
            r = rand.Next(9);
            while (true)
            {
                if (prerand == r)
                {
                    r = rand.Next(8);
                }
                else
                    break;
            }

            switch (r)  //난수에 따른 
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                           bmole[0, 0] = true;
                           bmole[1, 2] = true;
                           bbump[2, 0] = true;
                        }
                    }
                    break;

                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            bmole[0, 1] = true;
                            bmole[2, 1] = true;
                            bbump[1, 2] = true;
                        }
                    }
                    break;

                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                           bmole[0, 2] = true;
                           bmole[1, 1] = true;
                           bbump[0, 0] = true;
                        }
                    }
                    break;

                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                           bmole[1, 0] = true;
                           bmole[0, 1] = true;
                            bbump[2, 2] = true;
                        }
                    }
                    break;

                case 4:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            bmole[1, 1] = true;
                            bmole[2, 2] = true;
                            bbump[0, 2] = true;
                        }
                    }
                    break;

                case 5:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            bmole[1, 2] = true;
                           bmole[2, 0] = true;
                            bbump[0, 1] = true;
                        }
                    }
                    break;

                case 6:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            bmole[2, 0] = true;
                            bmole[1, 0] = true;
                            bbump[0, 2] = true;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                          bmole[2, 1] = true;
                          bmole[0, 2] = true;
                           bbump[1, 0] = true;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                           bmole[2, 2] = true;
                           bmole[0, 0] = true;
                           bbump[2, 1] = true;
                        }
                    }
                    break;

            }
           Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bhammer = true;                //마우스 클릭시 내려간 망치로 바뀜
                ham.Play();                  //망치 소리
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (bmole[i, j] == true)    //일반 두더지 나타나면
                        {
                            if (rec[i, j].Contains(e.X, e.Y))  //일반 두더지 망치에 맞으면
                            {
                                hitting.Play();            //두더지 맞을때 소리
                                hit++;
                                bmole[i, j] = false;           //그냥 두더지 없어지고
                                btouch[i, j] = true;           //맞은 두더지 나옴
                            }
                        }
                        if(bbump[i,j]==true)  //폭탄 두더지 나타나면
                        {
                            if (rec[i, j].Contains(e.X, e.Y))  //폭탄 두더지 망치에 맞으면
                            {
                                burn.Play();                   //폭탄두더지 잡을 때 소리
                                bbump[i, j] = false;           //폭탄 두더지 없어지고
                                bburn[i, j] = true;           //폭탄맞은 두더지 나옴
                                miss++;             //폭탄 두더지 잡으면 miss 증가
                            }
                        }
                    }
                }
            }

            lbHit.Text = "Hit: " + hit;      //두더지 맞으면 hit 증가된거 보여줌
            lbMiss.Text = "Miss: " + miss;   //폭탄두더지 터지면 miss 증가되고 점수 올라간거 바로 보여주기 위함
          Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
                hamx= e.X - 10; // 마우스 따라올 망치 위치
                hamy= e.Y - 60;
         
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bhammer = false;  // 버튼 떼면 원래 망치
        }

        private void Btclose_Click(object sender, EventArgs e)
        {
            bt.Play();  //버튼음
            Application.Exit(); //모든 폼 종료
        }

        void makeRec()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rec[i, j] = new Rectangle(recx + (recw + gap) * i, recy + (rech) * j, recw, rech);
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(map, 0, 0, 450, 550); //배경

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bmole[i, j] == true)
                    {
                        g.DrawImage(mole, rec[i, j]); // 스위치에 따라 나타날 두더지
                    }
                    if (btouch[i, j] == true)
                    {

                        g.DrawImage(sickmole, rec[i, j]);   // 맞은 두더지 
                    }
                    if (bbump[i,j]==true)
                    {
                        g.DrawImage(bumpmole,rec[i,j]); // 스위치에 따라 나타날 폭탄두더지
                    }
                    if (bburn[i, j] == true)
                    {

                        g.DrawImage(burnmole, rec[i, j]);   // 폭탄맞은 두더지 
                    }
                }
            }

            if (bhammer==false)
            {
                g.DrawImage(hammer, hamx, hamy);   //마우스 안누를때 망치
            }
            else
            {
                g.DrawImage(hithammer, hamx, hamy);  //마우스 누를 때 망치
            }
        }
    }

}
