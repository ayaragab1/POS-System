import { InvoiceDetails } from './../_models/invoice/invoice-details';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceService } from '../_service/invoice/invoice.service';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css'],
})
export class InvoiceDetailsComponent implements OnInit {
  Filtration: any;
  countRow:any;
  quantityPerItem:any;
  priceOne:any;
  totalPayment:any;
  constructor(
    public router: Router,
    public invoiceService: InvoiceService,
    private ac: ActivatedRoute
  ) {}
  inv:InvoiceDetails[] = []
  invoiceDetails: InvoiceDetails = new InvoiceDetails();


  ngOnInit(): void {
    this.ac.params.subscribe((par) => {
      this.invoiceService.getInvoiceById(par.id).subscribe((result) => {
        this.invoiceDetails = result;
        this.quantityPerItem=this.invoiceDetails.tQuantity_PerItem
        this.priceOne=this.invoiceDetails.unit_Price;
        this.totalPayment=this.invoiceDetails.total_Paymant;

        // console.log(this.invoiceDetails);
        this.countRow=this.invoiceDetails.product_Name?.length;
        console.log(this.countRow)
      });
    });

  }
}
