using Microsoft.EntityFrameworkCore;
using POS__System.Models;
using POS__System.Services.Interface;
using POS__System.ViewModels;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;


namespace POS__System.Services
{
    public class ProductMoc : IProduct
    {
        private ApiDbContext _db;

        public ProductMoc(ApiDbContext db)
        {
            _db = db;

        }
        public async Task<NewProductModel> Add(NewProductModel P)
        {
            //ID 
            int PId = _db.Products.ToList().Count() > 0 ? _db.Products.Max(x => x.Product_ID) + 1 : 1;
            int TypeID = _db.Types.FirstOrDefault(a => a.Type_Name == P.Type_Name).Type_ID; 
            var NewProduct = new Products()
            {
                Product_ID = PId,
                Product_Name = P.Product_Name,
                Unit_Price = P.Unit_Price,
                Type_ID= TypeID, 
            };
            _db.Products.Add(NewProduct);
            _db.SaveChanges();
            return P;

        }



        public async Task<bool> DeleteProduct(int ID)
        {
            var Data = await _db.Products.FindAsync(ID);
            if (Data == null)
                return false;
            else
            {
                _db.Products.Remove(Data);
                _db.SaveChanges();
                return true;
            }
        }

        public async Task<List<NewProductModel>> GetAll()
        {
            List<NewProductModel> All = new List<NewProductModel>();
            var AllData =await  _db.Products.Include(a => a.Types).ToListAsync(); 
                
            var len = _db.Products.Count(); 
            for (int i = 0; i < len; i++)
            {
                All.Add(new NewProductModel()
                {
                    Product_ID = AllData[i].Product_ID,
                    Product_Name = AllData[i].Product_Name,
                    Unit_Price = AllData[i].Unit_Price,
                    Type_ID = AllData[i].Type_ID,
                    Type_Name = AllData[i].Types.Type_Name, 

                });
            }

            return All;
        }

        public async Task<List<Types>> GetAllType()
        {
            var allType = await _db.Types.ToListAsync();
            return allType; 
        }
    }
}
