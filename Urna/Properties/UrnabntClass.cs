using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Media;


namespace Urna.Properties
{
    public class UrnabntClass
    {
        static SoundPlayer confirmar = new SoundPlayer("C:\\Users\\cleod\\Downloads\\Urna\\img\\Sound\\Confirmar.wav");
        static SoundPlayer bnts = new SoundPlayer("C:\\Users\\cleod\\Downloads\\Urna\\img\\Sound\\botoes.wav");
        public static void InicializarBotoesDaUrna()
        {
            PictureBox[] Urnabnts = Form1.UserInterface.Urnabnts;
            Label inputN = Form1.UserInterface.entrada;
            for (int i = 0; i < Urnabnts.Length; i++)
            {
                int UrnabntNumber = i;
                PictureBox localUrnabnt = Urnabnts[i];
                Urnabnts[i].MouseDown += (sender, e) => ChangeImageOnMouseDown(localUrnabnt, UrnabntNumber);
                Urnabnts[i].MouseUp += (sender, e) => ChangeImageOnMouseUp(localUrnabnt, UrnabntNumber);
                Urnabnts[i].Click += (sender, e) => UrnaClick(temNumero(inputN), inputN, UrnabntNumber);
            }
        }

        private static bool temNumero(Label label)
        {
            string text = label.Text;
            return Regex.IsMatch(text, @"\d+");
        }

        private static Image file(int numero, bool press)
        {
            if (press) { return Image.FromFile("C:\\Users\\cleod\\Downloads\\Urna\\img\\n" + numero + "_down.jpg"); }
            else { return Image.FromFile("C:\\Users\\cleod\\Downloads\\Urna\\img\\n" + numero + ".jpg"); }
        }

        public static void ChangeImageOnMouseDown(PictureBox bnt, int numero)
        {
            bnt.Image = file(numero, true);
        }

        public static void ChangeImageOnMouseUp(PictureBox bnt, int numero)
        {
            bnt.Image = file(numero, false);
        }
        public static void UrnaClick(bool temNumero, Label inputN, int numero)
        {
            if (!temNumero && numero < 11)
            {
                MostrarNumero(inputN, numero);
            }
            else if (numero == 12)
            {
                LimparInput(inputN);
            }
            else if (numero == 11)
            {
                ProcessarVoto(inputN);
            }
        }

        private static void MostrarNumero(Label inputN, int numero)
        {
            inputN.Text = Convert.ToString(numero);
            ResultsManager.urnaPainelShow(numero);
            bnts.Play();
        }

        private static void LimparInput(Label inputN)
        {
            inputN.Text = "";
            ResultsManager.urnaPainelHide();
            bnts.Play();
        }

        private static void ProcessarVoto(Label inputN)
        {
            int voto;
            bool tentativa = Int32.TryParse(inputN.Text, out voto);
            if (tentativa)
            {
                Candidatos.AdicionarVoto(voto);
                ResultsManager.ResultsPage();
                confirmar.Play();
                MostrarFim();
                Pergunta(inputN);
            }
        }

        private static void MostrarFim()
        {
            Label labelFim = new Label();
            labelFim.Text = "FIM";
            labelFim.Font = new Font("Arial", 36, FontStyle.Bold);
            labelFim.TextAlign = ContentAlignment.MiddleCenter;
            labelFim.Dock = DockStyle.Fill;
            Form1.Panel.Controls.Add(labelFim);
            OcultarItens(labelFim);
        }

        private static void OcultarItens(Label labelFim)
        {
            foreach (Control c in Form1.Panel.Controls)
            {
                if (c != labelFim)
                {
                    c.Visible = false;
                }
            }
        }

        private static void Pergunta(Label inputN)
        {
            DialogResult resposta = MessageBox.Show("Você quer votar novamente?", "Obrigado Pelo voto", MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                ReinicializarUrna(inputN);
            }
        }

        private static void ReinicializarUrna(Label inputN)
        {
            foreach (Control c in Form1.Panel.Controls)
            {
                if (c is Label && c.Text == "FIM")
                {
                    c.Visible = false;
                }
                else
                {
                    c.Visible = true;
                }
            }
            inputN.Text = "";
            ResultsManager.urnaPainelHide();
        }
    }
 
}

