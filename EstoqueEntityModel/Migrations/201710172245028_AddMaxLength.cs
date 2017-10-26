namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxLength : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProdutoEstoques");
            AlterColumn("dbo.ProdutoEstoques", "numeroProduto", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.ProdutoEstoques", "nomeProduto", c => c.String(maxLength: 20));
            AlterColumn("dbo.ProdutoEstoques", "DescricaoProduto", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.ProdutoEstoques", "numeroProduto");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProdutoEstoques");
            AlterColumn("dbo.ProdutoEstoques", "DescricaoProduto", c => c.String());
            AlterColumn("dbo.ProdutoEstoques", "nomeProduto", c => c.String());
            AlterColumn("dbo.ProdutoEstoques", "numeroProduto", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProdutoEstoques", "numeroProduto");
        }
    }
}
