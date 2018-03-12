using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public abstract class Repository<T> : IRepository<T> where T : class 
{
    private readonly DbContext _ctx;

    public Repository()
    {
        
    }

    public Repository(DbContext ctx)
    {
        _ctx = ctx;
    }

    public T Create(T instance)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public T Get()
    {
        return _ctx.Set<T>().FirstOrDefault();   
    }

    public IList<T> GetAll(Expression<Func<T, bool>> func)
    {
        return _ctx.Set<T>().Where(func).ToList();
    }

    public void Update(T instance)
    {
        throw new NotImplementedException();
    }
}
