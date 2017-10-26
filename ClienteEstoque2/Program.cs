using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteEstoque2.ServicoEstoque2;
using EstoqueLibrary;

namespace ClienteEstoque2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("WS2007HttpBinding_IProductsService");

            // ---------------------------------------------------- TESTE 1
             Console.WriteLine("Teste 1: Verificar o estoque atual do Produto 1");
             Console.WriteLine("Estoque do produto 1: {0}", proxy.consultarEstoque("1000"));
             Console.WriteLine();

             // ---------------------------------------------------- TESTE 2
             Console.WriteLine("Teste 2: Remover 20 unidades para este produto");
             if (proxy.removerEstoque("1000", 20)) Console.WriteLine("Removido 20 unidades do produto 1: {0}", proxy.consultarEstoque("1000"));
             else Console.WriteLine("Erro ao remover 20 unidades ao produto 1!");
             Console.WriteLine();

             // ---------------------------------------------------- TESTE 3
             Console.WriteLine("Teste 3: Verificar o estoque do Produto 1 novamente");
             Console.WriteLine("Estoque do produto 1: {0}", proxy.consultarEstoque("1000"));
             Console.WriteLine();

             // ---------------------------------------------------- TESTE 4
             Console.WriteLine("Teste 4: Verificar o estoque atual do Produto 5");
             Console.WriteLine("Estoque do produto 5: {0}", proxy.consultarEstoque("5000"));
             Console.WriteLine();

             // ---------------------------------------------------- TESTE 5
             Console.WriteLine("Teste 5: Remover 10 unidades para este produto");
             if (proxy.removerEstoque("5000", 10)) Console.WriteLine("Removido 10 unidades do produto 5: {0}", proxy.consultarEstoque("5000"));
             else Console.WriteLine("Erro ao remover 10 unidades ao produto 5!");
             Console.WriteLine();

             // ---------------------------------------------------- TESTE 6
             Console.WriteLine("Teste 6: Verificar o estoque do Produto 5 novamente");
             Console.WriteLine("Estoque do produto 5: {0}", proxy.consultarEstoque("5000"));
             Console.WriteLine();

             // Disconnect from the service 
             proxy.Close();
             Console.WriteLine("Press ENTER to finish");
             Console.ReadLine();
        }
    }
}
