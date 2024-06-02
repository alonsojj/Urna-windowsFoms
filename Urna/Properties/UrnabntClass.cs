using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;


namespace Urna.Properties
{
    public class UrnabntClass
    {
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
            if (!temNumero && numero<11)
            {
                inputN.Text = Convert.ToString(numero); 
                ResultsManager.urnaPainelShow(numero);

            }
            if (numero == 12)
            {
                inputN.Text = "";
                ResultsManager.urnaPainelHide();
            }
            if ( numero == 11)
            {
                int voto;
                bool tentativa;
                tentativa = Int32.TryParse(inputN.Text, out voto);
                if (tentativa) { 
                    Candidatos.AdicionarVoto(voto);
                    ResultsManager.ResultsPage();
                }
            }
        }

        private static bool temNumero(Label label)
        {
            string text = label.Text;
            return Regex.IsMatch(text, @"\d+");
        }




    }
}
