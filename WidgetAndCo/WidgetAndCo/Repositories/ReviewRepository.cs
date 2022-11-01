using Microsoft.EntityFrameworkCore;
using WidgetAndCo.Contexts;
using WidgetAndCo.Models.ReadModels;

namespace WidgetAndCo.Repositories;

public class ReviewRepository : BaseRepository<ReviewReadModel, CosmosReadModelContext>
{
    private readonly CosmosReadModelContext _context;
    
    public ReviewRepository(CosmosReadModelContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReviewReadModel>> GetAllForProduct(Guid productId)
    {
        return await _context.Set<ReviewReadModel>().Where(x => x.ProductId == productId).ToListAsync();
    }
}