using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueCliente.ServicoEstoque;
//using EstoqueLibrary;

namespace ClienteEstoque1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            // ---------------------------------------------------- TESTE 1
            Console.WriteLine("Teste 1: Adicionar um produto (por exemplo, Produto 11)");
            Produto produto = new Produto
            {
                NumeroProduto = "11",
                NomeProduto = "Produto 11",
                DescricaoProduto = "Produto teste 11",
                EstoqueProduto = 1100
            };

            if (proxy.incluirProduto(produto) == true) Console.WriteLine("Adicionado com sucesso!");
            else Console.WriteLine("Erro ao adicionar!");
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 2
            Console.WriteLine("Teste 2: Remover o produto 10");
            if (proxy.removerProduto("10000")) Console.WriteLine("Removido com sucesso!");
            else Console.WriteLine("Erro ao remover!");
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 3
            Console.WriteLine("Teste 3: Listar todos os produtos");
            List<string> nomes = proxy.ListarProdutos().ToList();

            foreach (string nome in nomes)
            {
                Console.WriteLine("Nome: {0}", nome);
            }
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 4
            Console.WriteLine("Teste 4: Verificar todas as informações do Produto 2");
            Produto prod4 = proxy.verProduto("2000");
            if (prod4 != null)
            {
                Console.WriteLine("Numero: {0}", prod4.NumeroProduto);
                Console.WriteLine("Nome: {0}", prod4.NomeProduto);
                Console.WriteLine("Descricao: {0}", prod4.DescricaoProduto);
                Console.WriteLine("Estoque: {0}", prod4.EstoqueProduto);
            }
            else
            {
                Console.WriteLine("Erro ao listar produto 2!");
            }
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 5
            Console.WriteLine("Teste 5: Adicionar 10 unidades para este produto");
            if(proxy.adicionarEstoque("2000", 10)) Console.WriteLine("Add 10 unidades ao produto 2: {0}", proxy.consultarEstoque("2000"));
            else Console.WriteLine("Erro add 10 unidades ao produto 2!");
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 6
            Console.WriteLine("Teste 6: Verificar o estoque do Produto 2");
            Console.WriteLine("Estoque do produto 2: {0}", proxy.consultarEstoque("2000"));
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 7
            Console.WriteLine("Teste 7: Verificar o estoque atual do Produto 1");
            Console.WriteLine("Estoque do produto 1: {0}", proxy.consultarEstoque("1000"));
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 8
            Console.WriteLine("Teste 8: Remover 20 unidades para este produto");
            if (proxy.removerEstoque("1000", 20)) Console.WriteLine("Removido 20 unidades do produto 1: {0}", proxy.consultarEstoque("1000"));
            else Console.WriteLine("Erro ao remover 20 unidades ao produto 1!");
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 9
            Console.WriteLine("Teste 9: Verificar o estoque do Produto 1 novamente");
            Console.WriteLine("Estoque do produto 1: {0}", proxy.consultarEstoque("1000"));
            Console.WriteLine();

            // ---------------------------------------------------- TESTE 10
            Console.WriteLine("Teste 10: Verificar todas as informações do Produto 1");
            Produto prod1 = proxy.verProduto("1000");
            if (prod1 != null)
            {
                Console.WriteLine("Numero: {0}", prod1.NumeroProduto);
                Console.WriteLine("Nome: {0}", prod1.NomeProduto);
                Console.WriteLine("Descricao: {0}", prod1.DescricaoProduto);
                Console.WriteLine("Estoque: {0}", prod1.EstoqueProduto);
            }
            else
            {
                Console.WriteLine("Erro ao listar produto 2!");
            }
            Console.WriteLine();

            // Disconnect from the service 
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
