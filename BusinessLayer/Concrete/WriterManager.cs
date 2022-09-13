﻿using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager:IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TAdd(WriterUser t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _writerDal.Delete(t);
        }

        public WriterUser TGetByID(int id)
        {
            return _writerDal.GetByID(id);  
        }

        public List<WriterUser> TGetList()
        {
            return _writerDal.GetList();
        }

        public void TUpdate(WriterUser t)
        {
            _writerDal.Update(t);
        }
    }
}