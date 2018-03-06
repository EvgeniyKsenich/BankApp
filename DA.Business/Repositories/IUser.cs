﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Business.Repositories
{
    public interface IUser<T> where T:class
    {
        T GetUser(string Username);

        IEnumerable<T> GetList();

        void Add(T User);
    }
}
