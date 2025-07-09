using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EFCargoCustomerRepository : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;

        public EFCargoCustomerRepository(CargoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CargoCustomer> GetCargoCustomerById(string id)
        {
            var values = await _context.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefaultAsync();
            return values;
        }
    }
}
