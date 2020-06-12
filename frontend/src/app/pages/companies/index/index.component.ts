import { Component } from '@angular/core';

import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss'],
})
export class IndexComponent {

  companies = [];
  constructor(
    private http: HttpService,
    private alert: AlertService,
  ) {
    this.GetCompanies();
  }
  GetCompanies() {
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

  onCreateConfirm( event ): void {
    const company = event.newData;
    // if ( company.Name && company.Description && company.Price ) {
      this.http.Post('/company/create', company).subscribe(
        data => {
          this.alert.Success('invoice is generated');
        },
        err => {
          this.alert.Error(err.message);
        },
      );
    // }
  }

  onEditConfirm( event ): void {
    const company = event.newData;
    if (event.data !== company) {
      // if ( company.Name && company.Description && company.Price ) {
        this.http.Post('/company/edit', company).subscribe(
        data => { this.alert.Success('invoice is generated'); },
        err => { this.alert.Error(err.message); },
      );
      // }
    }
  }

  delete( item ): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.http.Post('/company/delete', item).subscribe(
        data => {
          this.alert.Success('invoice is generated');
          this.GetCompanies();
        },
        err => {
          this.alert.Error(err.message);
        },
      );
    }
  }
}


