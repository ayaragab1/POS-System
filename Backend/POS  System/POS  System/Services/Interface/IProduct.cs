using POS__System.Models;
using POS__System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Services.Interface
{
   public interface IProduct
    {
        Task<List<NewProductModel>> GetAll();
        Task<NewProductModel> Add(NewProductModel P);
        Task<List<Types>> GetAllType();
        Task<bool> DeleteProduct(int ID);
    }
}
