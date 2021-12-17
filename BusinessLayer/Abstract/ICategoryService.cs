using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);

        //Category Silme işlemi yapmak için bulma işlemi için genericRepository içerisine get methodu tanımlamıştık. Burada da ilk olarak bulma işlemi için gerekli olan imza atılır.
        Category GetByID(int id); //Get methodu T türünde olduğu için burada Category yazıyoruz. VE ID ye göre işlem yapılacağını belirtiyoruz.
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
