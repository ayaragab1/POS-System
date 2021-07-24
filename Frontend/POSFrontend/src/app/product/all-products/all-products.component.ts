import { InvoiceService } from './../../_service/invoice/invoice.service';
import { InvoiceDetails } from './../../_models/invoice/invoice-details';
import { Products } from './../../_models/product/products';
import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/_service/product/product.service';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.css'],
})
export class AllProductsComponent implements OnInit {
  allProducts: Products[] = [];
  productsFilter: Products[] = [];
  searchVal: any;
  addProduct: Products = new Products();
  fieldArray: Array<any> = [];
  productName: any;
  productPrice: any;
  totalPayment: any;
  QTY: any = 1;
  objToBeSent: InvoiceDetails = new InvoiceDetails();
  test: Array<any> = [];
  numberPrice: Array<any> = [];
  totalBill: any;
  pricePerOne: any;
  itemArray: number = 0;
  changeColor: boolean = false;
  array: any;
  types: any;
  cardtype:any;
  constructor(
    private productService: ProductService,
    private invoiceService: InvoiceService
  ) {}

  //search for product by name
  checkSearchVal() {
    debugger;
    this.productsFilter = this.array.slice();
    let filtered: Products[] = [];
    if (this.searchVal && this.searchVal != '') {
      for (let selected of this.productsFilter) {
        if (
          selected.product_Name
            .toLowerCase()
            .search(this.searchVal.toLowerCase()) != -1
        ) {
          filtered.push(selected);
        }
      }
    } else {
      for (let selected of this.productsFilter) {
        filtered.push(selected);
      }
    }

    this.productsFilter = filtered.slice();
  }
  //add new Product
  addNewProduct(type:any) {
    console.log(type);
    this.addProduct.type_Name=type;
    this.productService.addNewProduct(this.addProduct).subscribe((a) => {
      window.location.reload();
      console.log(this.addProduct);
    });
  }
  //get data from card
  getData(event: any) {
    var target = event.currentTarget;
    this.productName = target.children[0].innerText;
    this.productPrice = target.children[1].innerText;
    this.pricePerOne = this.productPrice.split(' ', 1);
    this.totalBill = this.pricePerOne * this.QTY;
    this.fieldArray.push({
      name: this.productName,
      quntity: this.QTY,
      price: this.pricePerOne,
      total: this.totalBill,
    });
    this.totalInv();
  }
  //total Payment
  totalInv() {
    this.itemArray = 0;
    this.test = [];
    for (let i = 0; i < this.fieldArray.length; i++) {
      this.test.push(this.fieldArray[i].total);
      console.log(this.test);
    }
    //to Do Sum Operation
    this.itemArray = this.test.reduce(function (a: number, b: number) {
      return a + b;
    });

  }
  //Increase Quantity
  increase(i: any) {
    debugger;
    console.log(i);
    var newQ = (this.fieldArray[i].quntity += 1);
    var price = this.fieldArray[i].price;
    this.totalBill = price * newQ;
    this.fieldArray[i].total = this.totalBill;
    this.totalInv();
  }
  //decrease Quantity
  decrease(i: any) {
    debugger;
    if (this.fieldArray[i].quntity == 1) {
      this.fieldArray[i].quntity == 1;
    } else {
      var newQ = (this.fieldArray[i].quntity -= 1);
      var price = this.fieldArray[i].price;
      this.totalBill = price * newQ;
      this.fieldArray[i].total = this.totalBill;
      this.totalInv();
    }
  }
  //delete Row from table
  deleteRow(index: any) {
    this.fieldArray.splice(index, 1);
    this.totalInv();

  }
  changeType(type: any) {
    debugger;
    console.log(type);
    //  var types= type.target.childNodes[0].data;
    this.cardtype = type.target.outerText;
    console.log(this.cardtype );

    this.productsFilter = this.allProducts.slice();
    let filtered: Products[] = [];

    for (let selected of this.productsFilter) {
      if (selected.type_Name == this.cardtype ) {
        filtered.push(selected);
      }
    }
    this.array = filtered.slice();
    this.productsFilter = filtered.slice();
    //  debugger;
    // this.changeColor=true;
  }
  //send data to backend
  addBill() {
    console.log(this.fieldArray);
    var productnames = [];
    var quantities = [];
    var totalpriceperitem = [];
    var unitprices: Array<any> = [];

    for (let i = 0; i < this.fieldArray.length; i++) {
      unitprices.push(this.fieldArray[i].price);
      this.numberPrice = unitprices.map(function (value) {
        return Number(value);
      });
      productnames.push(this.fieldArray[i].name);
      quantities.push(this.fieldArray[i].quntity);
      totalpriceperitem.push(this.fieldArray[i].total);

      this.objToBeSent.total_Paymant = totalpriceperitem;
      this.objToBeSent.unit_Price = this.numberPrice;
      this.objToBeSent.tQuantity_PerItem = quantities;
      this.objToBeSent.product_Name = productnames;
    }
    this.objToBeSent.total_Price = this.itemArray;
    console.log(this.objToBeSent);

    this.invoiceService.addInvoice(this.objToBeSent).subscribe((a) => {});
    this.fieldArray.splice(0);
    this.itemArray = 0;
  }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe((a) => {
      this.allProducts = a;
      for (let i = 0; i < this.allProducts.length; i++) {
        if (this.allProducts[i].type_Name == 'Sandwiches') {
          this.productsFilter.push(this.allProducts[i]);
        }
      }
      this.array =this.productsFilter;
      console.log(a);
    });
    this.productService.getAllTypes().subscribe((a) => {
     this.types=a;
     console.log(a)
    });
    this.cardtype="Sandwiches"

  }
}
