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
using System.IO;
using System.Resources;

//Wyctor Fogos da Rocha - IEE7 2020/1
namespace Day_at_Race_ultima_tentativa
{
    public partial class Form1 : Form
    {

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Form1()
        {
            
            InitializeComponent();
            player.SoundLocation = "C:/Users/Wyctor/Desktop/Projetos_MVS/Day_at_Race_ultima_tentativa/Day_at_Race_ultima_tentativa/Audio_Corrida_de_cavalo.wav";
            player.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        { //Corrida começa ao clicar em 'Corram!!'
            
            Walk();
            //Audio.Play(Properties.Resources.Audio_corrida_de_cavalo, AudioPlayMode.BackGround);
        }
        // Enquanto não chegarem na linha de chegada, continuam correndo
        public void Walk()
        {
            //Atualiza o valor da posição ('X') de cada imagem 
            int maior_dist = 0;
            int[] pictures_positions_X;
            pictures_positions_X = new int[4];
            int X_max = 110;
            int X_min = 0;

            // Obtem o valor a ser acrescido
            int[] aux_array;
            aux_array = new int[4];

            // Enquanto não chegarem na linha de chegada, continuam correndo
            while (maior_dist <= 650)
            {
                //Atualiza a nova coordenada 'X' de cada figura
                for (int i = 0; i < aux_array.Length; i++)
                { 
                    aux_array[i] = Convert.ToInt32(Random_X(X_min, X_max).GetValue(i));
                    pictures_positions_X[i] = pictureBox1.Location.X + aux_array[i];
                }

                //Verifacação de quem está mais na frente 
                maior_dist = pictures_positions_X[0];
                for (int i = 0; i < pictures_positions_X.Length ; i++)
                 {
                     if (pictures_positions_X[i] > maior_dist)
                     {
                         maior_dist = pictures_positions_X[i];
                     }
                 }
                //Console.WriteLine(pictures_positions);
                //Setando os novos valores das coordenadas

                //Mudando_posicao()
                pictureBox1.Location = new Point(pictures_positions_X[0], pictureBox1.Location.Y);
                pictureBox2.Location = new Point(pictures_positions_X[1], pictureBox2.Location.Y);
                pictureBox3.Location = new Point(pictures_positions_X[2], pictureBox3.Location.Y);
                pictureBox4.Location = new Point(pictures_positions_X[3], pictureBox4.Location.Y);

                //Delay no tempo do loop
                int milliseconds = 1000;
                System.Threading.Thread.Sleep(milliseconds);
            }
            player.Stop();
            //Após o final da corrida, é analisado o que 
            Dog_winner(pictures_positions_X, maior_dist);
        }

        public Array Random_X(int min, int max)
        {
            Random rnd = new Random();
            int[] aux_array_final;
            aux_array_final = new int[4];
            for (int i = 0; i < 4; i++)
            {
                aux_array_final[i] = rnd.Next(min, max);
                //Console.WriteLine("{0,6}", aux_array[i]);
            }
            return aux_array_final;
        }

        private void Dog_winner(Array array, int maior_dist)
        {
            //É obtido o número do cachorro vencedor
            int a = (Array.IndexOf(array, maior_dist)+1);
            MessageBox.Show("Dog " + a + " is the winner!");
        }


        public void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    

