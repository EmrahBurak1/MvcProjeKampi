﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager: IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com"); //Burada şartlı bir listeleme işlemi yapılıyor. receivermail admin@gmail.coma eşit olunca listele anlamına gelir.
        }

        public void MessageAdd(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
