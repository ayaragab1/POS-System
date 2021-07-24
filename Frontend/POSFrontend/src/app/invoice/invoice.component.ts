import { Invoice } from './../_models/invoice/invoice';
import { Component, OnInit } from '@angular/core';
import { InvoiceService } from '../_service/invoice/invoice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css'],
})
export class InvoiceComponent implements OnInit {
  constructor(private invoiceService: InvoiceService, public router: Router) {}
  allInvoices: Invoice[] = [];
  Invoicess: Invoice[] = [];
  id: any;
  toBeDel: any;

  getSearch(id: any) {
    console.log(id);
    console.log(typeof id);
    debugger;
    if (id != '') {
      this.allInvoices = this.allInvoices.filter((a) => a.invoice_Number == id);
    } else {
      this.allInvoices = this.Invoicess;
    }
  }
  deleteInvoice(idD: any) {
    this.toBeDel = idD;
  }
  delete() {
    this.invoiceService.deleteInvoice(this.toBeDel).subscribe((a) => {
      location.reload();
    });
  }
  details(id: any) {
    this.router.navigate(['/detailedInvoice/', id]);
  }
  ngOnInit(): void {
    this.invoiceService.getAllInvoices().subscribe((a) => {
      this.allInvoices = a;
      this.Invoicess = a;
      console.log(this.allInvoices);
    });
  }
}
