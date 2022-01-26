using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void ContactAdd(Contact contact);

        //Contact Silme işlemi yapmak için bulma işlemi için genericRepository içerisine get methodu tanımlamıştık. Burada da ilk olarak bulma işlemi için gerekli olan imza atılır.
        Contact GetByID(int id); //Get methodu T türünde olduğu için burada Category yazıyoruz. VE ID ye göre işlem yapılacağını belirtiyoruz.
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
