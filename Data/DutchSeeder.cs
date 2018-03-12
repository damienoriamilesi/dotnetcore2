using System.Linq;

public class DutchSeeder
{
    private readonly DutchContext _ctx;

    public DutchSeeder(DutchContext ctx)
    {
        _ctx = ctx;   
    }   

    public void Seed(){
        _ctx.Database.EnsureCreated();
        if(!_ctx.Products.Any()){
            
        }
    }
}