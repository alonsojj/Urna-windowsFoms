using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

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
        public static void urnaPainel(int numero)
        {
            Candidato Atual = Candidatos.GetCandidato(numero);
            Form1.UserInterface.urnaPanel[0].Text = Atual.Nome;
            Form1.UserInterface.urnaPanel[1].Text = Atual.Partido;
            Bitmap Foto = new Bitmap(Atual.Imagem);
            if (Foto != null ) { Form1.UserInterface.Urnafoto.Image = Foto; };
        }
    }
}
