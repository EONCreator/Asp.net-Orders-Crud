using AsuManagement.OrdersCrud.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsuManagement.OrdersCrud.Domain.Services.Data
{
    public class DatabaseInitializer
    {
        private readonly AppDbContext _context;

        public DatabaseInitializer(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedProviders()
        {
            if (await _context.Providers.AnyAsync())
                return;

            var providers = new List<Provider>() {
                new Provider("Поставщик 1"),
                new Provider("Поставщик 2"),
                new Provider("Тестовый поставщик"),
                new Provider("Новый поставщик"),
                new Provider("Поставщик 3")
            };
            _context.Providers.AddRange(providers);
            await _context.SaveChangesAsync();
        }

        public async Task Initialize()
        {
            await SeedProviders();
        }
    }
}
