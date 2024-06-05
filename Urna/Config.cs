using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using static System.Windows.Forms.LinkLabel;

namespace Urna
{

    internal class Config
    {


        private static int IndexCandidato = 2;
        private static List<Candidato> atual = Candidatos.GetCandidatos();
        private static TextBox[] textBoxs = Form1.UserInterface.TextConfig;
        public static void InicializarConfig()
        {
            Form1.UserInterface.bntsConfig[0].Click += (sender, e) => Backbnt();
            Form1.UserInterface.bntsConfig[1].Click += (sender, e) => Nextbnt();
            Form1.UserInterface.bntsConfig[2].Click += (sender, e) => SaveChanges();
        }
        private static void Backbnt()
        {
            IndexCandidato--;
            if (IndexCandidato < 2)
            {
                IndexCandidato = Candidatos.GetCandidatos().Count - 1;
            }
            ChangeCandidato();
        }
        private static void Nextbnt()
        {
            IndexCandidato++;
            if (IndexCandidato >= Candidatos.GetCandidatos().Count)
            {
                IndexCandidato = 2;
                
            }
            ChangeCandidato();
        }
            public static void ChangeCandidato()
            {

                textBoxs[0].Text = atual[IndexCandidato].Nome;
                textBoxs[1].Text = atual[IndexCandidato].Numero.ToString();
                textBoxs[2].Text = atual[IndexCandidato].Partido;
                textBoxs[3].Text = atual[IndexCandidato].Imagem;
                Form1.UserInterface.Graph[0].Image=ResultsManager.ImageShow(atual[IndexCandidato].Imagem);


            }
            private static void SaveChanges()
            {
                atual[IndexCandidato].Nome = textBoxs[0].Text;
                atual[IndexCandidato].Numero = Convert.ToInt32(textBoxs[1].Text);
                atual[IndexCandidato].Partido = textBoxs[2].Text;
                atual[IndexCandidato].Imagem = textBoxs[3].Text;
                ChangeCandidato();
            }



        }
    } 
