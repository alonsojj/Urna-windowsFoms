using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom.Compiler;
using System.Linq;
using System.Threading.Tasks;

namespace Urna
{
    public class Candidato
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeVotos { get; set; }
    }
    public static class Candidatos
    {
        public static List<Candidato> ListaCandidatos { get; set; } = new List<Candidato>();
        public static async Task DefinirCandidatosPadrao()
        {
            await Task.Run(() =>
            {
                Candidato[] candidatos = new Candidato[]
               {
                new Candidato {
                    Numero = 0,
                    Nome = "Nulo",
                    Partido = "Zero",
                    Imagem = "",
                    QuantidadeVotos = 0
                },
                new Candidato {
                    Numero = -1,
                    Nome = "Branco",
                    Partido = "Branco",
                    Imagem = "C:\\Users\\cleod\\Downloads\\Urna\\img\\Candidatos\\",
                    QuantidadeVotos = 0 },
                new Candidato {
                    Numero = 1,
                    Nome = "Chaves",
                    Partido = "PSL",
                    Imagem = "C:\\Users\\cleod\\Downloads\\Urna\\img\\Candidatos\\chaves.jpg",
                    QuantidadeVotos = 0
                },
                new Candidato {
                    Numero = 2,
                    Nome = "Barriga",
                    Partido = "PT",
                    Imagem = "C:\\Users\\cleod\\Downloads\\Urna\\img\\Candidatos\\barriga.jpg",
                    QuantidadeVotos = 0
                },
                new Candidato {
                    Numero = 3,
                    Nome = "Florinda",
                    Partido = "PSOL",
                    Imagem = "C:\\Users\\cleod\\Downloads\\Urna\\img\\Candidatos\\florinda.jpg",
                    QuantidadeVotos = 0
                },
                new Candidato {
                    Numero = 4,
                    Nome = "Kiko",
                    Partido = "Podemos",
                    Imagem = "C:\\Users\\cleod\\Downloads\\Urna\\img\\Candidatos\\kiko.jpg",
                    QuantidadeVotos = 0
                },
                new Candidato {
                    Numero = 5,
                    Nome = "Chiquinha",
                    Partido = "MDB",
                    Imagem = "C:\\Users\\cleod\\Downloads\\Urna\\img\\Candidatos\\Chiquinha.jpg",
                    QuantidadeVotos = 0
                }
               };

                foreach (Candidato candidato in candidatos)
                {
                    Candidatos.AdicionarCandidato(candidato);
                }
            });

        }
        public static void AdicionarCandidato(Candidato candidato)
        {
            ListaCandidatos.Add(candidato);
        }

        public static void RemoverCandidato(int numeroCandidato)
        {
            var candidato = ListaCandidatos.FirstOrDefault(c => c.Numero == numeroCandidato);
            if (candidato != null)
            {
                ListaCandidatos.Remove(candidato);
            }
        }

        public static Candidato GetCandidato(int numeroCandidato)
        {
            return ListaCandidatos.FirstOrDefault(c => c.Numero == numeroCandidato);
        }
        public static List<Candidato> GetCandidatos()
        {
            return ListaCandidatos;
        }
        public static void AdicionarVoto(int numeroDoCandidato)
        {
            int indiceDoCandidato = ListaCandidatos.FindIndex(c => c.Numero == numeroDoCandidato);
            if (indiceDoCandidato != -1)
            {
                ListaCandidatos[indiceDoCandidato].QuantidadeVotos++;
            }
            else
            {

             
               Console.WriteLine("Candidato não encontrado. Voto branco.");
               ListaCandidatos[1].QuantidadeVotos++;
             
            }
        }





    }
}
