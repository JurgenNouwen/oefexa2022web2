using PXLFunds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Models
{
    public class FundInfoOutputModel : FundInfoModel
    {
        public static FundInfoOutputModel FromFundInfo(Bank bank, Fund fund) {
            return new FundInfoOutputModel
            {
                BankName = bank.BankName,
                FundName = fund.FundName,
                FundValue = fund.FundValue,

            };
        }
    }
}
