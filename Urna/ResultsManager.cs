using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace Urna
{
    internal class ResultsManager
    {
        public static void ResultsPage()
        {
            List<Candidato> teste = Candidatos.GetCandidatos();
            Label[] labellist = Form1.UserInterface.resultsPage;
            for (int i = 0; i < labellist.Length; i++)
            {
                labellist[i].Text = Convert.ToString(teste[i].QuantidadeVotos);
            };
        }
        public static void urnaPainelShow(int numero)
        {
            //Torna visivel
            Candidato Atual = Candidatos.GetCandidato(numero);
            if (Atual.Nome != "")
            {
                for (int i = 0; i < Form1.UserInterface.Ocultlabels.Length; i++)
                {
                    Form1.UserInterface.Ocultlabels[i].Visible = true;
                }
                // Adiciona informação 

                Form1.UserInterface.urnaPanel[0].Text = Atual.Nome;
                Form1.UserInterface.urnaPanel[1].Text = Atual.Partido;

                if (Atual.Imagem != "")
                {

                    if (Uri.IsWellFormedUriString(Atual.Imagem, UriKind.Absolute))
                    {

                        using (WebClient client = new WebClient())
                        {
                            byte[] imageData = client.DownloadData(Atual.Imagem);
                            using (MemoryStream stream = new MemoryStream(imageData))
                            {
                                Form1.UserInterface.Urnafoto.Image = Image.FromStream(stream);
                                Form1.UserInterface.Urnafoto.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        Form1.UserInterface.Urnafoto.Image = new Bitmap(Atual.Imagem);
                        Form1.UserInterface.Urnafoto.Visible = true;
                    }
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
        }
    }
}
