using DataAccsessLayer.Abstract;
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
    public class EfExperienceDal : GenericRepository<Experience>, IExperienceDal
    {
        public EfExperienceDal(Context context) : base(context)
        {
        }
    }
}
