using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;

namespace _1052054_hw1
{
    public partial class Form1 : Form
    {
        int dx = -8, dy = -10;
       
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);

            pictureBox1.Visible = false;
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Random rn = new Random();
         
            Gl.glPointSize(2.0f);
            Gl.glColor3ub(255, 255, 255);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

           
            for (int i = 0; i < 300; i++)
            {   
                //-----星星大小隨機----//
                Gl.glPointSize(rn.Next(0,2));  //0~2之間大小, pointsize指令放在begin&end裡無效
                Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex2i(rn.Next(0, this.simpleOpenGlControl1.Size.Width),
                              rn.Next(0, this.simpleOpenGlControl1.Size.Height));
                Gl.glEnd();
            }
            Gl.glPointSize(5.0f); 

            Gl.glBegin(Gl.GL_POINTS);


            Gl.glColor3f(1.0f, 0.0f, 0.0f); // 紅

            Gl.glVertex2i(380, 290);


            Gl.glColor3f(1.0f, 0.5f, 0.0f); // 橙

            Gl.glVertex2i(410, 230);


            Gl.glColor3f(1.0f, 1.0f, 0.0f); // 黃

            Gl.glVertex2i(330, 165);


            Gl.glColor3f(0.0f, 1.0f, 0.0f); // 綠

            Gl.glVertex2i(285, 200);


            Gl.glColor3f(0.0f, 0.0f, 1.0f); // 藍

            Gl.glVertex2i(220, 180);


            Gl.glColor3f(1.0f, 0.0f, 1.0f); // 靛

            Gl.glVertex2i(165, 170);


            Gl.glColor3f(0.5f, 0.0f, 1.0f); // 紫

            Gl.glVertex2i(110, 110);


            Gl.glEnd();
               
          
        }
        //------飛碟-----//

        //----出現-----//
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible =true;
        }

        //----出現-----//
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        //----出現-----//
        private void button1_Click(object sender, EventArgs e)
        {
           
           timer1.Enabled = false;
          
        }

        //----出現-----//
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            pictureBox1.Top += dy;
            pictureBox1.Left += dx;
            //---怕超出格子---碰撞機制//
            if (pictureBox1.Left < 0)
            {
                dx = -1 * dx;
            }
            if (pictureBox1.Top < 0)
            {
                dy = -1 * dy;
            }
            if (pictureBox1.Bottom > this.simpleOpenGlControl1.Height)
            {
                dy = -1 * dy;
            }
            if (pictureBox1.Right > this.simpleOpenGlControl1.Width)
            {
                dx = -1 * dx;
            }
          

        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit(); //結束此應用程式
        }

       

        

        

        

        

       
    }
}
