﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>

    {
        //type name();
        List<T> List();

        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter);

        //void Update(T p);
        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter);

        void Update(T p);
    }
}

