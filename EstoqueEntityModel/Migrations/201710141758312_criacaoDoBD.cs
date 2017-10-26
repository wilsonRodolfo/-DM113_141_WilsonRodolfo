namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoDoBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoEstoques",
                c => new
                    {
                        numeroProduto = c.String(nullable: false, maxLength: 128),
                        nameProduto = c.String(),
                        DescricaoProduto = c.String(),
                        estoqueProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.numeroProduto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProdutoEstoques");
        }
    }
}
