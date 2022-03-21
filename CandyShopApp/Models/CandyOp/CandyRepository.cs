using CandyShopApp.Data;
using CandyShopApp.Models.CategoryOp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopApp.Models.CandyOp
{
    public class CandyRepository : ICandyRepository
    {
        private readonly AppDbContext _appDbContext;

        public CandyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Candy> GetAllCandy
        {
            get
            {
                return _appDbContext.Candies.Include(x => x.Category);
            }
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return _appDbContext.Candies.Include(x => x.Category).Where(x => x.IsOnSale == true);
            }
        }

        public Candy GetCandyById(int candyId)
        {
            return _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
