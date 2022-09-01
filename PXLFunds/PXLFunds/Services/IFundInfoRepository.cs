using PXLFunds.Data;
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


    }
}
