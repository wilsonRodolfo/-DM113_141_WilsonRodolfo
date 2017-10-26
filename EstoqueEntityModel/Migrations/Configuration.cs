namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EstoqueEntityModel.ProvedorEstoque>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EstoqueEntityModel.ProvedorEstoque context)
        {
            context.Produtos.AddOrUpdate(p => p.numeroProduto,
                new ProdutoEstoque { numeroProduto = "1000", nomeProduto = "Produto 1", DescricaoProduto = "Este é o produto 1", estoqueProduto = 100 },
                new ProdutoEstoque { numeroProduto = "2000", nomeProduto = "Produto 2", DescricaoProduto = "Este é o produto 2", estoqueProduto = 10 },
                new ProdutoEstoque { numeroProduto = "3000", nomeProduto = "Produto 3", DescricaoProduto = "Este é o produto 3", estoqueProduto = 200 },
                new ProdutoEstoque { numeroProduto = "4000", nomeProduto = "Produto 4", DescricaoProduto = "Este é o produto 4", estoqueProduto = 300 },
                new ProdutoEstoque { numeroProduto = "5000", nomeProduto = "Produto 5", DescricaoProduto = "Este é o produto 5", estoqueProduto = 400 },
                new ProdutoEstoque { numeroProduto = "6000", nomeProduto = "Produto 6", DescricaoProduto = "Este é o produto 6", estoqueProduto = 500 },
                new ProdutoEstoque { numeroProduto = "7000", nomeProduto = "Produto 7", DescricaoProduto = "Este é o produto 7", estoqueProduto = 30 },
                new ProdutoEstoque { numeroProduto = "8000", nomeProduto = "Produto 8", DescricaoProduto = "Este é o produto 8", estoqueProduto = 30 },
                new ProdutoEstoque { numeroProduto = "9000", nomeProduto = "Produto 9", DescricaoProduto = "Este é o produto 9", estoqueProduto = 400 },
                new ProdutoEstoque { numeroProduto = "10000", nomeProduto = "Produto 10", DescricaoProduto = "Este é o produto 10", estoqueProduto = 2 }
            );
            context.SaveChanges();
        }
    }
}
