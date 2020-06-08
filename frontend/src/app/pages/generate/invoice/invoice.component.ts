import { Component } from '@angular/core';
import { fruits } from './fruits-list';
// import { generate } from 'rxjs';
import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'ngx-spinner',
  templateUrl: 'invoice.component.html',
  styleUrls: ['invoice.component.scss'],
})
export class InvoiceComponent {
  constructor(
    private http: HttpService,
    private alert: AlertService,
  ) { }

  fruits = fruits;

  users: { name: string, title: string }[] = [
    { name: 'Carla Espinosa', title: 'Nurse' },
    { name: 'Bob Kelso', title: 'Doctor of Medicine' },
    { name: 'Janitor', title: 'Janitor' },
    { name: 'Perry Cox', title: 'Doctor of Medicine' },
    { name: 'Ben Sullivan', title: 'Carpenter and photographer' },
  ];

  receivingData = false;
  downloadReady = false;

  generateInvoices() {
    let d;
    this.receivingData = true;

    this.http.Get('/invoice/generate').subscribe(
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
