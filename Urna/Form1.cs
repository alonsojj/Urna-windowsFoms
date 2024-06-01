using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Urna.Properties;

namespace Urna
{
    public partial class Form1 : Form
    {

        public static UIElements UserInterface { get; private set; }


        public Form1()
        {
            InitializeComponent();
            UserInterface = new UIElements();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InicializarTudo();
        }

        private async void InicializarTudo()
        {
            await Candidatos.DefinirCandidatosPadrao();
            InicializarControles();
            InicializarControlesConfig();
        }

        private void InicializarControles()
        {
            UserInterface.entrada = inputN;
            UserInterface.Urnabnts = new PictureBox[]
            {
            UrnaN0, UrnaN1, UrnaN2, UrnaN3,
            UrnaN4, UrnaN5, UrnaN6, UrnaN7,
            UrnaN8, UrnaN9, UrnaBranco, UrnaConfirma, UrnaCorrige
            };
            UserInterface.resultsPage = new Label[]
            {
            label1, label2, label3, label4, label5, label6, label7
            };
            UserInterface.urnaPanel = new Label[] { textNome, textPt };
            UrnabntClass.InicializarBotoesDaUrna();
        }

        private void InicializarControlesConfig()
        {
            UserInterface.TextConfig = new TextBox[] { textBoxNome, textBoxNumero, textBoxPartido, textBoxUrl };
            UserInterface.bntsConfig = new Button[] { button1, button2, Salvar };
            Config.InicializarConfig();
            UserInterface.Urnafoto = UrnaFt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class UIElements
    {
        public Label entrada { get;  set; }
        public PictureBox[] Urnabnts { get;  set; }
        public Label[] resultsPage { get; set; }
        public Label[] urnaPanel { get; set; }
        public Button[] bntsConfig { get; set; }
        public  TextBox[] TextConfig { get; set; }
        public PictureBox Urnafoto { get; set; }
    }
}
