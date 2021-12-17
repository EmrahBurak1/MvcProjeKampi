using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        //Burada bir constructor method oluşturmak gerekiyor ki istediğimiz interface e ulaşalım.
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id); //WriterID bizim disaridan gonderdigimiz id ye eşit olunca değer dondur anlamında.
        }

        public List<Writer> GetList()
        {
            return _writerDal.List(); //Getlist methodu listeleme işlemi gerçekleştirecek.
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);//Burada insert ile ekleme işlemi ypaılıyor. Parametre olarak gönderilen writer eklenir.
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
