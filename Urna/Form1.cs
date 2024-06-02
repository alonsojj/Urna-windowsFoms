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
        private Timer timer;


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
            UrnabntClass.InicializarBotoesDaUrna();
            InicializarControlesConfig();
            Config.InicializarConfig();
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
            
            UserInterface.Ocultlabels = new Label[]
            {
                UrnaNome,UrnaPt,label13,textConfirma,LinhaUrna,UrnaSeuvoto,tituloUrna
            };
        }

        private void InicializarControlesConfig()
        {
            UserInterface.TextConfig = new TextBox[] { textBoxNome, textBoxNumero, textBoxPartido, textBoxUrl };
            UserInterface.bntsConfig = new Button[] { button1, button2, Salvar };
            
            UserInterface.Urnafoto = UrnaFt;
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

        public  Label[] Ocultlabels { get; set; }
    }
}
