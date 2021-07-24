import { InvoiceComponent } from './invoice/invoice.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllProductsComponent } from './product/all-products/all-products.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';

const routes: Routes = [
  {path:"invoice" , component:InvoiceComponent},
  {path : "detailedInvoice/:id" , component:InvoiceDetailsComponent },
  {path : "home" , component:AllProductsComponent },
  {path:"" , component:AllProductsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
