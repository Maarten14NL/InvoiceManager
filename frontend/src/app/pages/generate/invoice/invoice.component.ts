import { Component } from '@angular/core';
import { fruits } from './fruits-list';
// import { generate } from 'rxjs';
import { HttpService } from '../../../services/http.service';

@Component({
  selector: 'ngx-list',
  templateUrl: 'invoice.component.html',
  styleUrls: ['invoice.component.scss'],
})
export class InvoiceComponent {
  constructor(private http: HttpService) { }

  fruits = fruits;

  users: { name: string, title: string }[] = [
    { name: 'Carla Espinosa', title: 'Nurse' },
    { name: 'Bob Kelso', title: 'Doctor of Medicine' },
    { name: 'Janitor', title: 'Janitor' },
    { name: 'Perry Cox', title: 'Doctor of Medicine' },
    { name: 'Ben Sullivan', title: 'Carpenter and photographer' },
  ];
  foods;
  generateInvoices() {
    this.http.url = 'http://ergast.com/api/f1/seasons.json';

    // console.log(this.http.get());
  }
}
