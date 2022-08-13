using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteFlower.Core;

namespace EliteFlower.Services.Products
{
    public partial interface IProductService
    {
        //Firm for create a manufacture
        Task<bool> Insert(Product product);

        //Firm for update a manufacture
        Task<bool> Update(Product product);

        //Firm for delete a manufacture
        Task<bool> Delete(int id);

        //Firm for get all manufactures
        List<Product> GetAll();

        //Firm for get one manufacture
        Task<Product> GetById(int id);
    }
}
