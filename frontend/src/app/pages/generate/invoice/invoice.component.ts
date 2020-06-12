import { Component } from '@angular/core';
// import { generate } from 'rxjs';
import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'ngx-spinner',
  templateUrl: 'invoice.component.html',
  styleUrls: ['invoice.component.scss'],
})
export class InvoiceComponent {

  companies = [];
  constructor(
    private http: HttpService,
    private alert: AlertService,
  ) {
    this.http.Get('/company/read').subscribe(
      data => {
        this.companies = data.companies;

        // this.alert.Success('invoice is generated');
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  invoiceCompanies = [];
  setInvoiceCompanies() {
    this.invoiceCompanies = [];
    this.companies.forEach((value, index) => {
      if (value.isChecked) {
        this.invoiceCompanies.push(value);
      }
    });
  }

  receivingData = false;
  downloadReady = false;

  generateInvoices() {
    let d;
    this.receivingData = true;

    this.http.Post('/invoice/generate', this.invoiceCompanies).subscribe(
      data => {
        d = data;
        this.alert.Success('invoice is generated');
        this.receivingData = false;
        this.downloadReady = true;
      },
      err => {
        this.alert.Error(err.message);
        this.receivingData = false;
      },
    );
  }
  downloading = false;
  downloadInvoices() {
    this.downloading = true;
    this.http.Get('/invoice/download').subscribe(
      data => {
        this.alert.Success('invoice is generated');
        this.downloading = false;
        this.downloadReady = false;
      },
      err => {
        this.alert.Error(err.message);
        this.downloading = false;
      },
    );

  }
}
