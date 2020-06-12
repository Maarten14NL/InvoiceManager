import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})

export class CreateComponent {

  companyForm;
  companies = [];
  constructor(
    private http: HttpService,
    private alert: AlertService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {
    this.companyForm = this.formBuilder.group({
      Name: '',
      CustomerNumber: '',
      Iban: '',
      IbanAscription: '',
      PhoneNumber: '',
      Website: '',
      Email: '',
      MandateDate: '',
    });
  }

  onSubmit(companyData) {
    // Process checkout data here
    this.http.Post('/company/create', companyData).subscribe(
      data => {
        if (data.success) {
          this.alert.Success('Company is created');
          this.router.navigate(['/companies']);
        } else {
          this.alert.Error('Company is NOT created');
        }
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  onCreateConfirm( event ): void {
    const company = event.newData;
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
}


