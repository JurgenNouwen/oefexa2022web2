using Microsoft.EntityFrameworkCore;
using PXLFunds.Data;
using PXLFunds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PXLFunds.Services
{
    public class FundInfoDbRepository : IFundInfoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;


        public FundInfoDbRepository(IHttpClientFactory httpClientFactory, ApplicationDbContext context)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;

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

        public IEnumerable<FundInfoModel> GetAll()
        {
            HttpClient client = _httpClientFactory.CreateClient(ApiConstants.FundInfoHttpClientName);

            HttpResponseMessage response = client.GetAsync("fundinfo").Result;
            if (response.IsSuccessStatusCode) { 
            IList<FundInfoModel> fundInfos = response.Content.ReadAsAsync<IList<FundInfoModel>>().Result;
                return fundInfos;
            }
            else
            {
                return Enumerable.Empty<FundInfoModel>();
            }
        }

    }
}
