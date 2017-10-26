namespace EstoqueEntityModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class ProvedorEstoque : DbContext
    {
        // Your context has been configured to use a 'ProvedorEstoque' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EstoqueEntityModel.ProvedorEstoque' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProvedorEstoque' 
        // connection string in the application configuration file.
        public ProvedorEstoque()
            : base("name=ProvedorEstoque")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ProdutoEstoque> Produtos { get; set; }
    }

    public class ProdutoEstoque
    {
        [Key, MaxLength(10)]
        public string numeroProduto { get; set; }

        [MaxLength(20)]
        public string nomeProduto { get; set; }

        [MaxLength(50)]
        public string DescricaoProduto { get; set; }

        public int estoqueProduto { get; set; }
    }
}