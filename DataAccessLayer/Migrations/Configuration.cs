namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //Migration nedir? Projede değişiklik yaptık bu değişikliği sql'e yansıtmak için bizim c# ile sql arasındaki köprü görevini gören migrationdur.
    //Bu bölümdeki açıklamalar mvcprojekampi katmanı içerisinde bulunan web.config içerisinde anlatıldı.
    //Sql server management içerisine bakılırsa DbMvcKamp isimli database'in oluştuğu görülür. İçerisinde tablolar, veri tipleri eklenmiş olur. Ayrıca yeni bir database diagram oluşturulduğunda tablolar arasındaki ilişkilerin de düzgün bir şekilde oluşturulduğu görülür.
    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Concrete.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccessLayer.Concrete.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
