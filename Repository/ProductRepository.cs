using System;
using System.Linq;
using System.Linq.Expressions;
using coreapp.Data;
public class ProductRepository : Repository<Product>
{
    private readonly DutchContext _ctx;

    public ProductRepository(DutchContext ctx)
    {
        _ctx = ctx;
    }

    public void GetData()
    {
        var ids = new []{ "1","2","3","4" };
        var query = ids.Where(GetPredicate);
    }

    public bool GetPredicate(string x)
    {
        var predicate = x == "1";
        predicate = predicate && x == "2";

        return predicate;
    }
}