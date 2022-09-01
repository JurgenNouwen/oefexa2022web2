using Microsoft.EntityFrameworkCore;
using PXLFunds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Services
{
    public class FundInfoDbRepository : IFundInfoRepository
    {
        private readonly ApplicationDbContext _context;

        public FundInfoDbRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public IEnumerable<Bank> GetBankName()
        {
            return _context.Bank.Include(p => p.BankName).ToList();
        }

        public IEnumerable<Fund> GetFundName()
        {
            return _context.Fund.Include(p => p.FundName).ToList();

        }

        public IEnumerable<Fund> GetFundValue()
        {
            return _context.Fund.Include(p => p.FundValue).ToList();

        }
    }
}
