﻿using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.EntityFramework
{
    public class EfWriterDal : GenericRepository<WriterUser>, IWriterDal
    {
        public EfWriterDal(Context context) : base(context)
        {
        }
    }
}