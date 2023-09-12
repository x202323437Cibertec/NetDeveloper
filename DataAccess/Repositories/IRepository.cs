﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int pId);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity pEntity);
        void Remove(TEntity pEntity);
        int Count();
    }
}
