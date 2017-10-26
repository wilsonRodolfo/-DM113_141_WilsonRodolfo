namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoEstoques", "nomeProduto", c => c.String());
            DropColumn("dbo.ProdutoEstoques", "nameProduto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoEstoques", "nameProduto", c => c.String());
            DropColumn("dbo.ProdutoEstoques", "nomeProduto");
        }
    }
}
