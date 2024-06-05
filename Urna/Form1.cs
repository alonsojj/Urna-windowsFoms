using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public static Panel Panel { get; private set; }



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
            InicializarResultsPage();
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

            UserInterface.urnaPanel = new Label[] { textNome, textPt };
            Panel = panel5;
            UserInterface.Ocultlabels = new Label[]
            {
                UrnaNome,UrnaPt,LinhaUrna,label13,textConfirma,UrnaSeuvoto,tituloUrna
            };


        }

        private void InicializarControlesConfig()
        {
            UserInterface.TextConfig = new TextBox[] { textBoxNome, textBoxNumero, textBoxPartido, textBoxUrl };
            UserInterface.bntsConfig = new Button[] { button1, button2, Salvar };

            UserInterface.Urnafoto = UrnaFt;
        }
        private void InicializarResultsPage()
        {
            UserInterface.resultsPageVotos = new Label[]
            {
                 votoNulo,votoBranco,voto1, voto2, voto3,voto4, voto5
            };
            UserInterface.resultsPageVotosNB = new Label[]
            {
                 votoBranco,votoNulo
            };
            UserInterface.resultsPageNomes = new Label[]
            {
                 nome1,nome2,nome3,nome4,nome5
            };
            UserInterface.resultsPageFotos = new PictureBox[]
            {
                 resultadosFotos1, resultadosFotos2,resultadosFotos3, resultadosFotos4,resultadosFotos5
            };
            UserInterface.resultsPageProgressBars = new ProgressBar[]
            {
                progressBar1, progressBar2,progressBar3, progressBar4, progressBar5
            };
            UserInterface.resultsPageProgressBarsNB = new ProgressBar[]
            {
               progressBar00, progressBar0
            };
            UserInterface.resultsPagePercent = new Label[]
            {
                porcentagem1, porcentagem2, porcentagem3, porcentagem4, porcentagem5
            };

            UserInterface.Graph = new PictureBox[]
            {
                pictureBox1
            };
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bntMain_Click(object sender, EventArgs e)
        {
            panel2.Visible= true;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.BringToFront();
        }

        private void bntResult_Click(object sender, EventArgs e)
        {
            ResultsManager.ResultsPage();
            panel3.Visible = true;
            panel4.Visible = false;
            panel2.Visible = false;
            panel3.BringToFront();

        }

        private void bntConfig_Click(object sender, EventArgs e)
        {
            Config.ChangeCandidato();
            panel4.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.BringToFront();
        }
    }

    public class UIElements
    {
        public Label entrada { get;  set; }
        public PictureBox[] Urnabnts { get;  set; }
        public Label[] resultsPageVotos { get; set; }
        public Label[] resultsPageNomes { get; set; }
        public Label[] resultsPageVotosNB { get; set; }
        public Label[] resultsPagePercent { get; set; }
        public PictureBox[] resultsPageFotos { get; set; }


        public ProgressBar[] resultsPageProgressBars { get; set; }
        public ProgressBar[] resultsPageProgressBarsNB { get; set; }
        public Label[] urnaPanel { get; set; }
        public Button[] bntsConfig { get; set; }
        public  TextBox[] TextConfig { get; set; }
        public PictureBox Urnafoto { get; set; }

        public  Label[] Ocultlabels { get; set; }
        public PictureBox[] Graph {  get; set; }
    }
}
