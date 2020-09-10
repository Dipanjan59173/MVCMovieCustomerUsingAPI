namespace MovieCustomerWithAuthMVC_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Issubscribedtocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ISSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribe", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "ISSubscribedToNewsLetter");
        }
    }
}
