import { HttpClient } from '@angular/common/http';
import { Products } from './../../_models/product/products';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {}
  getAllProducts() {
    return this.http.get<Products[]>(
      'https://localhost:44353/api/Product/GetAllProducts'
    );
  }
  addNewProduct(addNew: Products) {
    return this.http.post(
      'https://localhost:44353/api/Product/AddProduct',
      addNew
    );
  }
}
