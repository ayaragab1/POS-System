using POS__System.Models;
using POS__System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Services.Interface
{
    public interface IInvoice
    {
        Task<List<GetAllInvoices>> GetAll();
        Task<InvoiceDetailsModel> Add(InvoiceDetailsModel Inv);
        Task<InvoiceDetailsModel> GetInvoiceByID(int ID);
        Task<bool> DeleteInvoiceDetails(int ID);
    }
}
