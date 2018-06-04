﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeBar.Web.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _appDbContext.Pies.ToList();
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.SingleOrDefault(p => p.Id == pieId);
        }
    }
}
