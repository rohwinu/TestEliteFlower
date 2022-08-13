using EliteFlower.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EliteFlower.Services.ManufactureService
{
    public partial interface IManufactureService
    {
        //Firm for create a manufacture
        Task<bool> Insert(Manufacture manufacture);

        //Firm for update a manufacture
        Task<bool> Update(Manufacture manufacture);

        //Firm for delete a manufacture
        Task<bool> Delete(int id);

        //Firm for get all manufactures
        List<Manufacture> GetAll();

        //Firm for get one manufacture
        Task<Manufacture> GetById(int id);
    }
}
