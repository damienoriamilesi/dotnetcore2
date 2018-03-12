using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public interface IRepository<T>
{
    T Get();
    IList<T> GetAll(Expression<Func<T,bool>> func);
    void Delete(int id);
    void Update(T instance);
    T Create(T instance);
}
