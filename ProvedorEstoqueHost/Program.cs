﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueLibrary;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost productsServiceHost = new ServiceHost(typeof(ServicoEstoque));
            productsServiceHost.Open();
            Console.WriteLine("Service Running");

            Console.WriteLine("Press ANY key to finish...");
            Console.ReadLine();

            Console.WriteLine("Service Stopping");
            productsServiceHost.Close();
        }
    }
}
