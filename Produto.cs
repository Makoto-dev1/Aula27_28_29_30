using System;
using System.Collections.Generic;
using System.IO;

namespace Aula27_28_29_30_2
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        public Produto()
        {   

            //Solução do desafio
            string pasta = PATH.Split('/')[0];
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Cadastrar as linhas no arquivo csv
        /// </summary>
        /// <param name="prod"></param>
        public void Cadastrar(Produto prod)
        {            
            string[] linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Lemos o .csv e separamos em um array de linhas
        /// </summary>
        /// <returns>dados do produto</returns>
        public List<Produto> Ler()
        {

            // Criamos uma lista para guardar o retorno
            List<Produto> prod = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            // Varremos nossas linhas
            foreach(string linha in linhas)
            {
                // codigo=1;nome=Gibson;preco=5500
                string[] dado = linha.Split(";");

                // dado[0] = codigo=1
                // dado[1] = nome=Gibson
                // dado[2] = preco=5500

                Produto p   = new Produto();
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar(dado[1]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                prod.Add(p);
            }

            return prod;
        }

        /// <summary>
        /// Método que separa o símbolo de = da string do csv
        /// </summary>
        /// <param name="dado">Coluna do csv separada</param>
        /// <returns>string somente com o valor da coluna</returns>
        public string Separar(string dado)
        {
            // codigo=1
            // [0] = codigo
            // [1] = 1
            return dado.Split("=")[1];
        }

        /// <summary>
        /// Método que faz as linhas 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Produto nome e preço</returns>
        private string PrepararLinha(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }


    }
}