using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulador_de_Arquivo_Texto
{
    class Program
    {

        /// <summary>
        /// Ele ler cada linha escrita no arquivo que foi passado por parâmetro.
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        private static void ReadTxt(string nomeArquivo)
        {
            //File.Exists testa se existe o arquivo que deseja procurar, devolvendo true se existe e falso caso não exista.
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, nomeArquivo)))
            {
                //Environment.CurrentDirectory pega o caminho na maquina que está sendo executado seu programa. Exemplo: C:\Users\Usuario\Workbench\Manipulador de Arquivo Texto\Manipulador de Arquivo Texto\bin\Debug
                //Path.Combine junta os nome e separa por \. Exemplo: C:\Users\Usuario\Workbench\Manipulador de Arquivo Texto\Manipulador de Arquivo Texto\bin\Debug\<nomeArquivo>
                //File.ReadAllLines ler o arquivo e faz cada linha dele ser uma posição do vetor. Caso use File.RealAllText, ele ler todo o arquivo trazendo em uma string apenas.
                string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, nomeArquivo));
                Console.WriteLine("Está escrito essa(s) mensagem(s)");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                return;
            }
            Console.WriteLine("Não foi encontrado o arquivo desejado!!!");
        }

        /// <summary>
        /// Ele escreve uma nova linha dentro do arquivo passado por parâmetro.
        /// </summary>
        /// <param name="message">Mensagem que será salva no arquivo</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        private static void WriteTxt(string message, string nomeArquivo)
        {
            //File.AppendAllText salva uma nova linha dentro do arquivo. File.AppendAllLines salva um vetor dentro do arquivo, sendo que cada posição do vetor será uma linha nova adicionada dentro do arquivo.
            File.AppendAllText(Path.Combine(Environment.CurrentDirectory, nomeArquivo), message + Environment.NewLine);
        }

        /// <summary>
        /// Ele sobrescreve no arquivo passado por parâmetro.
        /// </summary>
        /// <param name="message">Mensagem que será salva no arquivo</param>
        /// <param name="nomeArquivo">>Nome do arquivo</param>
        private static void OverwriteTxt(string message, string nomeArquivo)
        {
            //File.WriteAllText sobrescreve uma mensagem novo dentro do arquivo. File.WriteAllLines sobrescreve o arquivo apartir de um vetor, sendo que cada posição do vetor será uma linha dentro do arquivo.
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, nomeArquivo), message + Environment.NewLine);
        }

        private static void OpcaoEscolhida(string value)
        {
            try
            {
                switch (value)
                {
                    case "1":
                        {
                            Console.WriteLine("Digite o nome do arquivo que deseja manipular.");
                            string nomeArquivo = Console.ReadLine();
                            ReadTxt(nomeArquivo);
                        }
                        break;

                    case "2":
                        {
                            Console.WriteLine("Digite o nome do arquivo que deseja manipular.");
                            string nomeArquivo = Console.ReadLine();
                            Console.WriteLine("Digite uma mensagem para salvar.");
                            string message = Console.ReadLine();
                            WriteTxt(message, nomeArquivo);
                        }
                        break;

                    case "3":
                        {
                            Console.WriteLine("Digite o nome do arquivo que deseja manipular.");
                            string nomeArquivo = Console.ReadLine();
                            Console.WriteLine("Digite uma mensagem para salvar.");
                            string message = Console.ReadLine();
                            OverwriteTxt(message, nomeArquivo);
                        }
                        break;

                    case "9":
                        return;

                    default:
                        {
                            Console.WriteLine("Digite uma opção Valida!!!");
                        }
                        break;

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void WriteMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção Abaixo:");
            Console.WriteLine("1 - Ler a(s) mensagem(s) no arquivo escolhido.");
            Console.WriteLine("2 - Escrever uma mensagem no arquivo escolhido.");
            Console.WriteLine("3 - Sobrescrever uma mensagem no arquivo escolhido.");
            Console.WriteLine("9 - Sair");
        }

        static void Main(string[] args)
        {
            string value = string.Empty;
            do
            {
                WriteMenu();
                value = Console.ReadLine();
                OpcaoEscolhida(value);
            }
            while (value != "9");
        }
    }
}
