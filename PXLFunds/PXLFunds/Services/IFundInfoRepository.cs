using PXLFunds.Data;
using PXLFunds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Services
{
    public interface IFundInfoRepository
    {
        IEnumerable<Bank> GetBankName();
        IEnumerable<Fund> GetFundName();
        IEnumerable<Fund> GetFundValue();
        IEnumerable<FundInfoModel> GetAll();




    }
}
