using Microsoft.EntityFrameworkCore;
using POS__System.Models;
using POS__System.Services.Interface;
using POS__System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Services
{
    public class InvoiceMoc : IInvoice
    {
        private ApiDbContext _db;
        public InvoiceMoc(ApiDbContext db)
        {
            _db = db;

        }

        public async Task<InvoiceDetailsModel> Add(InvoiceDetailsModel Inv)
        {
            int Inv_Id = _db.Invoices.ToList().Count() > 0 ? _db.Invoices.Max(x => x.Invoice_Number) + 1 : 1;
            var NewInv = new Invoice()
            {
                Invoice_Number = Inv_Id,
                Invoice_Date = DateTime.Now, 
                Total_Price = Inv.Total_Price,
            };
            _db.Invoices.Add(NewInv);
            var DetailsInvoice = new List<Invoice_Details>();

            for (int i = 0; i < Inv.Total_Paymant.Count; i++)
            {

                var ItemID = _db.Products.FirstOrDefault(x => x.Product_Name == Inv.Product_Name[i]);
                DetailsInvoice.Add(new Invoice_Details()
                {
                    Invoice_Number= Inv_Id,
                    Total_Payment = Inv.Total_Paymant[i],
                    TQuantity_PerItem = Inv.TQuantity_PerItem[i],
                    Product_ID = ItemID.Product_ID,
                    UnitPrice = Inv.Unit_Price[i],
                });
            }
            await _db.Invoice_Details.AddRangeAsync(DetailsInvoice);
            _db.SaveChanges();
            return Inv;
        }

        public async Task<List<GetAllInvoices>> GetAll()
        {
            var AllData = await _db.Invoices.ToListAsync();
            var Len = _db.Invoices.Count();
            List<GetAllInvoices> AllInvoice = new List<GetAllInvoices>();
            for (int i = 0; i < Len; i++)
            {
                AllInvoice.Add(new GetAllInvoices()
                {
                    Invoice_Number = AllData[i].Invoice_Number,
                    Invoice_Date = AllData[i].Invoice_Date,
                    Total_Price= AllData[i].Total_Price, 
                }) ;
            }
            return AllInvoice; 
        }
        public async Task<InvoiceDetailsModel> GetInvoiceByID(int ID)
        {
            var Invoice = await _db.Invoices.FindAsync(ID);
            var InvoiceDetails = _db.Invoice_Details.Where(x => x.Invoice_Number == Invoice.Invoice_Number).ToList();
            var Product_ID = await _db.Invoice_Details.FirstOrDefaultAsync(a => a.Invoice_Number == Invoice.Invoice_Number);

            List<string> Items = new List<string>();
            List<double> UnitPrice = new List<double>();
            List<double> TotalPayment = new List<double>();
            List<int> TQuantityPerItem = new List<int>();

            foreach (var item in InvoiceDetails)
            {
                var ItemRow = _db.Products.FirstOrDefault(x => x.Product_ID == item.Product_ID);
                Items.Add(ItemRow.Product_Name);
                UnitPrice.Add(ItemRow.Unit_Price);
                TotalPayment.Add(item.Total_Payment);
                TQuantityPerItem.Add(item.TQuantity_PerItem);
            }

            InvoiceDetailsModel InvoiceInfo = new InvoiceDetailsModel()
            {
                Invoice_Number = Invoice.Invoice_Number,
                Invoice_Date = Invoice.Invoice_Date,
                Product_Name = Items,
                Total_Price = Invoice.Total_Price,
                Total_Paymant = TotalPayment,
                TQuantity_PerItem = TQuantityPerItem,
                Unit_Price = UnitPrice

            };
            return InvoiceInfo;

        }

        public async Task<bool> DeleteInvoiceDetails(int ID)
        {
            var Data = await _db.Invoice_Details.Where(x => x.Invoice_Number== ID).FirstOrDefaultAsync();
            if (Data == null)
                return false;
            else
            {
                var Invoice = await _db.Invoices.Where(x => x.Invoice_Number == ID).FirstOrDefaultAsync();
                _db.Invoices.Remove(Invoice);
                _db.Invoice_Details.Remove(Data);
                _db.SaveChanges();
                return true;
            }
        }
    }
}
