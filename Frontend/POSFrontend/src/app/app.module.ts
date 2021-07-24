import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AllProductsComponent } from './product/all-products/all-products.component';
import { HeaderComponent } from './header/header.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { FormsModule } from '@angular/forms';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
@NgModule({
  declarations: [
    AppComponent,
    AllProductsComponent,
    HeaderComponent,
    InvoiceComponent,
    InvoiceDetailsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
