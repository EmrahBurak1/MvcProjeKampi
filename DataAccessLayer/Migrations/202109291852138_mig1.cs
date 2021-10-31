namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //Biz content ile writer arasında ilişki kurmak isterken nullable sorunu oluşmuştu ve ilgili satırlar yorum yapılarak devam edildi. Daha sonra yorum kaldırılıp satırlar düzenlenip tekrar migration yapılmak istendiğinde add-migration mig1 yazılarak yeni bir migration oluşturuldu. mig1 ise buna verilen isim. Her migration'a ayrı ayrı isim verilebilir. add-migratin mig1 yazılınca bu dosyayı oluşturdu. Daha sonra değişikliği database e aktarmak için update-database kullanılır.
    //Not: nullable oluşma nedeni aynı tablo içerisinde birden fazla ilişki olduğu için sorun çıkardı. Nullable ile çözüldü. sql management studio da diagramlara bakılarak ilişkiler detaylı olarak görülebilir.
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "WriterID", c => c.Int());
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropColumn("dbo.Contents", "WriterID");
        }
    }
}
