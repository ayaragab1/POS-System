import { InvoiceDetails } from './../../_models/invoice/invoice-details';
import { Invoice } from './../../_models/invoice/invoice';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class InvoiceService {
  getAllInvoices() {
    return this.http.get<Invoice[]>(
      'https://localhost:44353/api/Invoice/GetAllInvoices'
    );
  }
  getInvoiceById(id: any) {
    return this.http.get(
      'https://localhost:44353/api/Invoice/GetInvoicebyId?' + 'id=' + id
    );
  }
  addInvoice(addInvoice: InvoiceDetails) {
    return this.http.post(
      'https://localhost:44353/api/Invoice/AddInvoice',
      addInvoice
    );
  }
  deleteInvoice(id: any) {
    debugger;
    return this.http.delete(
      'https://localhost:44353/api/Invoice/DeleteInvoiceDetails?' + 'id=' + id
    );
  }

  constructor(private http: HttpClient) {}
}
