using Microsoft.AspNetCore.Identity;
using PXLFunds.Data;
using PXLFunds.Models;
using PXLFunds.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Services
{
    public class SeedDataRepository : ISeedDataRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _context;
        public SeedDataRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public void Initialise()
        {
            //Data models
            AddBankInfo();
            AddFundInfo();
            //Identity models
            AddRolesAsync();
            AddAdminUser();
        }
        private void AddBankInfo()
        {
            if (_context.Bank.Any())
            {
                var banks = new List<Bank>
                {
                    new Bank { BankName = "KBC"},
                    new Bank { BankName = "Argenta"},

                };
                banks.ForEach(s => _context.Bank.Add(s));
                _context.SaveChanges();
            }
        }
        private void AddFundInfo()
        {
            if (_context.Bank.Any()) {
                var funds = new List<Fund> {
                    new Fund { FundName = "KBC Green", Bank = _context.Bank.Find("KBC") , FundValue = 100},
                    new Fund { FundName = "KBC Yellow", Bank = _context.Bank.Find("KBC") , FundValue = 125},
                    new Fund { FundName = "ARG Brown", Bank = _context.Bank.Find("Argenta") , FundValue = 135},
                    new Fund { FundName = "ARG Black", Bank = _context.Bank.Find("Argenta") , FundValue = 140 },
                };
                funds.ForEach(s => _context.Fund.Add(s));
                _context.SaveChanges();
            }

        }
        private void AddRolesAsync()
        {
            if (_context.Roles.Any())
            {
                IdentityRole roleClient = new IdentityRole(ProgramInfo.Roles.ClientRole);
                IdentityRole roleAdmin = new IdentityRole(ProgramInfo.Roles.AdminRole);

                _roleManager.CreateAsync(roleClient);
                _roleManager.CreateAsync(roleAdmin);

            };
        }
        private void AddAdminUser()
        {
            if (_context.Users.Any())
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = ProgramInfo.AdminUser.UserName,
                    Email = ProgramInfo.AdminUser.Email,
                    PasswordHash = ProgramInfo.AdminUser.Password
                };

                _userManager.CreateAsync(user);

            }
        }
    }
}
