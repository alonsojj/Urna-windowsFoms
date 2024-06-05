using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Linq;

namespace Urna
{
    internal class ResultsManager
    {
        private static Label labelVotoBranco;
        private static Label labelVotoNulo;
        private static List<Candidato> todosCandidatos = Candidatos.GetCandidatos();
        public static void ResultsPage()
        {
            
            List<Candidato> candidatosVisiveis = ObterCandidatosVisiveis(todosCandidatos);
            AtualizarLabels(candidatosVisiveis);
            AtualizarProgressBars(candidatosVisiveis);
        }

        private static List<Candidato> ObterCandidatosVisiveis(List<Candidato> todosCandidatos)
        {
            return todosCandidatos.Where(c => c.Numero > 0).OrderByDescending(c => c.QuantidadeVotos).ToList();
        }

        private static void AtualizarLabels(List<Candidato> candidatosVisiveis)
        {
            Label[] labelnomes = Form1.UserInterface.resultsPageNomes;
            Label[] labelvotos = Form1.UserInterface.resultsPageVotos;
            PictureBox[] fotosResultados = Form1.UserInterface.resultsPageFotos;
            Form1.UserInterface.resultsPageVotos[1].Text = Convert.ToString(todosCandidatos[1].QuantidadeVotos);
            Form1.UserInterface.resultsPageVotos[0].Text = Convert.ToString(todosCandidatos[0].QuantidadeVotos);
            for (int i = 0; i < candidatosVisiveis.Count; i++)
            {
                if (i < labelnomes.Length)
                {
                    fotosResultados[i].Image = ImageShow(candidatosVisiveis[i].Imagem);
                    labelnomes[i].Text = Convert.ToString(candidatosVisiveis[i].Nome);
                    labelvotos[i].Text = Convert.ToString(candidatosVisiveis[i].QuantidadeVotos);
                    
                }
                else
                {
                    break;
                }
            }
        }

        private static void AtualizarProgressBars(List<Candidato> candidatosVisiveis)
        {
            ProgressBar[] progressBar = Form1.UserInterface.resultsPageProgressBars;
            Label[] labelPercent = Form1.UserInterface.resultsPagePercent;
            
            int totalVotos = todosCandidatos.Sum(c => c.QuantidadeVotos);
            for (int i = 0; i < Form1.UserInterface.resultsPageProgressBarsNB.Length; i++)
            {
                double porcentagemVotos = (double)todosCandidatos[i].QuantidadeVotos / totalVotos * 100;
                if ((int)porcentagemVotos != -2147483648)
                {
                    
                    Form1.UserInterface.resultsPageProgressBarsNB[i].Minimum = 0;
                    Form1.UserInterface.resultsPageProgressBarsNB[i].Maximum = 100;
                    Form1.UserInterface.resultsPageProgressBarsNB[i].Value = (int)porcentagemVotos;
                }
            }

            for (int i = 0; i < candidatosVisiveis.Count; i++)
            {
                if (i < progressBar.Length)
                {
                    double porcentagemVotos = (double)candidatosVisiveis[i].QuantidadeVotos / totalVotos * 100;
                    if ((int)porcentagemVotos!= -2147483648)
                    {
                        progressBar[i].Minimum = 0;
                        progressBar[i].Maximum = 100;
                        progressBar[i].Value = (int)porcentagemVotos;
                    }


                    labelPercent[i].Text = string.Format("{0:0.00}%", porcentagemVotos);
                }
                else
                {
                    break;
                }
            }
        }
        public static Image ImageShow(String imgUrl)
        {
            if (imgUrl != null)
            {

                if (Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
                {

                    using (WebClient client = new WebClient())
                    {
                        byte[] imageData = client.DownloadData(imgUrl);
                        using (MemoryStream stream = new MemoryStream(imageData))
                        {
                            return Image.FromStream(stream);
                        }
                    }
                }
                else
                {
                    return new Bitmap(imgUrl);
                }
            }
            else
            {
                return null;
            }
        }
        public static void urnaPainelShow(int numero)
        {
            //Torna visivel
            Candidato Atual = Candidatos.GetCandidato(numero);

            if (Atual.Numero != -1 && numero != 0)
            {
                for (int i = 0; i < Form1.UserInterface.Ocultlabels.Length; i++)
                {
                    Form1.UserInterface.Ocultlabels[i].Visible = true;
                }
                // Adiciona informação 

                Form1.UserInterface.urnaPanel[0].Text = Atual.Nome;
                Form1.UserInterface.urnaPanel[1].Text = Atual.Partido;

                Form1.UserInterface.Urnafoto.Image = ImageShow(Atual.Imagem);
                Form1.UserInterface.Urnafoto.Visible = true;

            }
            else if (numero == 0)
            {
                labelVotoNulo = new Label();
                labelVotoNulo.Text = "Voto Nulo";
                labelVotoNulo.Font = new Font("Arial", 36, FontStyle.Bold);
                labelVotoNulo.TextAlign = ContentAlignment.MiddleCenter;
                labelVotoNulo.Dock = DockStyle.Fill;
                labelVotoNulo.Visible = true;
                Form1.Panel.Controls.Add(labelVotoNulo);
                for (int i = 2; i < Form1.UserInterface.Ocultlabels.Length; i++)
                {
                    Form1.UserInterface.Ocultlabels[i].Visible = true;
                }
            }
            else
            {
                labelVotoBranco = new Label();
                labelVotoBranco.Text = "Voto em Branco";
                labelVotoBranco.Font = new Font("Arial", 36, FontStyle.Bold);
                labelVotoBranco.TextAlign = ContentAlignment.MiddleCenter;
                labelVotoBranco.Dock = DockStyle.Fill;
                Form1.Panel.Controls.Add(labelVotoBranco);
                for (int i = 2; i < Form1.UserInterface.Ocultlabels.Length; i++)
                {
                    Form1.UserInterface.Ocultlabels[i].Visible = true;
                }
            }
        }


        public static void urnaPainelHide()
        {
            for (int i = 0; i < Form1.UserInterface.Ocultlabels.Length; i++)
            {
                Form1.UserInterface.Ocultlabels[i].Visible = false;
            }
            Form1.UserInterface.Urnafoto.Visible = false;
            //
            Form1.UserInterface.urnaPanel[0].Text = null;
            Form1.UserInterface.urnaPanel[1].Text = null;
            foreach (Control c in Form1.Panel.Controls)
            {
                if (c == labelVotoBranco)
                {
                    c.Visible = false;
                }
                else if (c == labelVotoNulo)
                {
                    c.Visible = false;
                }
            }
        }



    }
}
