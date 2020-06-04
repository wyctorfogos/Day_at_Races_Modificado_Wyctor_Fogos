using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Wyctor Fogos da Rocha - IEE7 2020/1
namespace Day_at_Race_ultima_tentativa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { //Corrida começa ao clicar em 'Corram!!'
            Walk();
        }
        // Enquanto não chegarem na linha de chegada, continuam correndo
        public void Walk()
        {
            //Atualiza o valor da posição ('X') de cada imagem 
            int maior_dist = 0;
            int[] pictures_positions;
            pictures_positions = new int[4];
            int X_max = 110;
            int X_min = 0;
            
            // Obtem o valor a ser acrescido
            int[] aux_array;
            aux_array = new int[4];

            aux_array[0] = Convert.ToInt32(Random_X().GetValue(0));
            aux_array[1] = Convert.ToInt32(Random_X().GetValue(1));
            aux_array[2] = Convert.ToInt32(Random_X().GetValue(2));
            aux_array[3] = Convert.ToInt32(Random_X().GetValue(3));

            // Enquanto não chegarem na linha de chegada, continuam correndo
            while (maior_dist <= 650)
            {
                //PlaySimpleSound();
                pictures_positions[0] = pictureBox1.Location.X + aux_array[0];
                pictures_positions[1] = pictureBox2.Location.X + aux_array[1];
                pictures_positions[2] = pictureBox3.Location.X + aux_array[2];
                pictures_positions[3] = pictureBox4.Location.X + aux_array[3];

                for (int i = 0; i < 4; i++)
                {
                    maior_dist = pictures_positions[0];
                    if (pictures_positions[i] > maior_dist)
                    {
                        maior_dist = pictures_positions[i];
                    }
                }

                //Setando os novos valores das coordenadas

                pictureBox1.Location = new Point(pictures_positions[0], pictureBox1.Location.Y);
                pictureBox2.Location = new Point(pictures_positions[1], pictureBox2.Location.Y);
                pictureBox3.Location = new Point(pictures_positions[2], pictureBox3.Location.Y);
                pictureBox4.Location = new Point(pictures_positions[3], pictureBox4.Location.Y);

                //Delay no tempo do loop
                int milliseconds = 500;
                System.Threading.Thread.Sleep(milliseconds);
            }

        }

        public void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        //Valor a ser acrescentado na coordenada 'X'
       /*public int Changepictureposition_X(int min, int max)
        {
            Random random = new Random();
            int caminhou_X = random.Next(min, max);
            //Console.WriteLine(caminhou_X);
            return caminhou_X;
        }*/

        public Array Random_X()
        {
            Random rnd = new Random();
            int[] aux_array_final;
            aux_array_final= new int[4];
            for (int i = 0; i < 4; i++)
            {
                aux_array_final[i] = rnd.Next(0, 111);
                //Console.WriteLine("{0,6}", aux_array[i]);
            }
            return aux_array_final;
        }

        /*private void PlaySimpleSound()
        {
            using (var soundPlayer = new SoundPlayer(@"C:\Windows\Media\Fillymonic_Orchestra-Corrida_de_cavalo.wav"))
            {
                soundPlayer.PlaySync(); // can also use soundPlayer.PlaySync()
            }
        }*/


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
