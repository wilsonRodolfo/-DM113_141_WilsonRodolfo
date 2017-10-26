using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueLibrary
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public List<string> ListarProdutos()
        {
            List<string> produtos = new List<string>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    produtos = (from ProdutoEstoque in database.Produtos select ProdutoEstoque.nomeProduto).ToList();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return produtos;
        }

        public bool incluirProduto(Produto produto)
        {
            bool ret = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    //Verifica se já não existe o produto
                    int cont = (from p in database.Produtos where p.numeroProduto.Equals(produto.NumeroProduto) select p).ToList().Count;

                    if (cont == 0)
                    {
                        ProdutoEstoque prod = new ProdutoEstoque();
                        prod.numeroProduto = produto.NumeroProduto;
                        prod.nomeProduto = produto.NomeProduto;
                        prod.estoqueProduto = produto.EstoqueProduto;
                        prod.DescricaoProduto = produto.DescricaoProduto;

                        database.Produtos.Add(prod);

                        database.SaveChanges();
                        ret = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return ret;
        }

        public bool removerProduto(string numeroProduto)
        {
            bool ret = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    //Verifica se existe o produto
                    ProdutoEstoque prod = (from p in database.Produtos where (p.numeroProduto == numeroProduto) select p).First();
                    if (prod != null)
                    {

                        database.Produtos.Remove(prod);

                        database.SaveChanges();
                        ret = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return ret;
        }

        public int consultarEstoque(string numeroProduto)
        {
            int ret = -1;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    //Verifica se existe o produto
                    ProdutoEstoque prod = (from p in database.Produtos where p.numeroProduto.Equals(numeroProduto) select p).First();
                    if (prod != null)
                    {
                        ret = prod.estoqueProduto;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return ret;
        }

        public bool adicionarEstoque(string numeroProduto, int quantidade)
        {
            bool ret = false;

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    //Verifica se existe o produto
                    ProdutoEstoque prod = (from p in database.Produtos where p.numeroProduto.Equals(numeroProduto) select p).First();
                    if (prod != null)
                    {
                        prod.estoqueProduto += quantidade;
                        //database.Produtos.Add(prod); //Com o Add não funcionou

                        database.SaveChanges();
                        ret = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return ret;
        }

        public bool removerEstoque(string numeroProduto, int quantidade)
        {
            bool ret = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    //Verifica se existe o produto
                    ProdutoEstoque prod = (from p in database.Produtos where (p.numeroProduto == numeroProduto) select p).First();
                    if (prod != null)
                    {
                        prod.estoqueProduto -= quantidade;
                        //database.Produtos.Add(prod);

                        database.SaveChanges();
                        ret = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return ret;
        }

        public Produto verProduto(string numeroProduto)
        {
            Produto produto = null;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    //Verifica se existe o produto
                    ProdutoEstoque prod = (from p in database.Produtos where p.numeroProduto.Equals(numeroProduto) select p).First();
                    if (prod != null)
                    {
                        produto = new Produto()
                        {
                            NomeProduto = prod.nomeProduto,
                            NumeroProduto = prod.numeroProduto,
                            EstoqueProduto = prod.estoqueProduto,
                            DescricaoProduto = prod.DescricaoProduto
                        };
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return produto;
        }

    }
}
