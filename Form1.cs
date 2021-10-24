using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yapayzeka_Odev_Berkozgul_Tictoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Sıfırla();
        }
        Player asil;
        List<Button> buttons;
        Random r = new Random();
        int kullaniciwin = 0;
        int bilgisayarwin = 0;

        

        public enum Player
        {
            X, O
        }

        private void oyuncu(object sender, EventArgs e)
        {
            var button = (Button)sender;
            asil = Player.X;
            button.Text = asil.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
            buttons.Remove(button);
            Kontrol();
            AImoves.Start();
        }

        private void AImove(object sender, EventArgs e)
        {
            
            if (buttons.Count > 0)
            {
                int index = r.Next(buttons.Count); 
                buttons[index].Enabled = false; 

                asil = Player.O; 
                buttons[index].Text = asil.ToString(); 
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon; 
                buttons.RemoveAt(index); 
                Kontrol(); 
                AImoves.Stop(); 
            }
        }

        private void restartGame(object sender, EventArgs e)
        {
            Sıfırla();
        }

        void Butonyukle()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

        }
        void Sıfırla()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true; 
                    ((Button)X).Text = "?"; 
                    ((Button)X).BackColor = default(Color); 
                }
            }
            Butonyukle();
        }

        void Kontrol()
        {
            
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                
                AImoves.Stop(); 
                MessageBox.Show("Oyuncu Kazandı"); 
                kullaniciwin++; 
                label1.Text = "Oyuncu- " + kullaniciwin; 
                Sıfırla(); 
            }
            
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {

                
                AImoves.Stop(); 
                MessageBox.Show("Bilgisayar Kazandı"); 
                bilgisayarwin++; 
                label2.Text = "Bilgisayar- " + bilgisayarwin; 
                Sıfırla(); 
            }
        }
    }
}
