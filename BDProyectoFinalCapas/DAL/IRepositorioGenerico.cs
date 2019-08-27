﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL
{
   public interface IRepositorioGenerico<T> where T : class
    {
        IQueryable<T> ListarTodo();

    }
}
