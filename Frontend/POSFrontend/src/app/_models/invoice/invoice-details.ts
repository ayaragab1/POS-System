export class InvoiceDetails {
  constructor(

    public invoice_ID?:number,
    public invoice_Date?:Date,
    public total_Price?:number ,
    public  total_Paymant?: any,
    public  tQuantity_PerItem?: any[] ,
    public  product_ID?: any[] ,
    public  product_Name?: any[],
    public unit_Price?: any[] ,
  ){
  }
}
