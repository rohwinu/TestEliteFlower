using EliteFlower.Core;
using EliteFlower.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteFlower.Services.ManufactureService
{
    public partial class ManufactureService : IManufactureService
    {
        private readonly eliteflowerContext _eliteflowerContext;

        public ManufactureService(eliteflowerContext eliteflowerContext)
        {
            _eliteflowerContext = eliteflowerContext;
        }

        public async Task<bool> Delete(int id)
        {
            Manufacture manufacture = _eliteflowerContext.Manufactures.First(x => x.Id == id);
            _eliteflowerContext.Remove(manufacture);
            await _eliteflowerContext.SaveChangesAsync();
            return true;
        }

        public List<Manufacture> GetAll()
        {
            return  _eliteflowerContext.Manufactures.ToList();
        }

        public async Task<Manufacture> GetById(int id)
        {
            return await _eliteflowerContext.Manufactures.FindAsync(id);
        }

        public async Task<bool> Insert(Manufacture manufacture)
        {
            _eliteflowerContext.Add(manufacture);
            await _eliteflowerContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Manufacture manufacture)
        {
            _eliteflowerContext.Manufactures.Update(manufacture);
            await _eliteflowerContext.SaveChangesAsync();
            return true;
        }
    }
}
