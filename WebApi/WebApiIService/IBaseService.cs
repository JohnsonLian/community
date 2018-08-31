using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiIService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
    }
}
