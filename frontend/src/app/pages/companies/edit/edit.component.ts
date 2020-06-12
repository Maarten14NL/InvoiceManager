import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
})

export class EditComponent {

  companyForm;
  companies = [];
  constructor(
    private http: HttpService,
    private alert: AlertService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    this.companyForm = this.formBuilder.group({
      Id: Number,
      Name: '',
      CustomerNumber: '',
      Iban: '',
      IbanAscription: '',
      PhoneNumber: '',
      Website: '',
      Email: '',
      MandateDate: '1/1/1900 12:00:00 AM',
    });
    const id = this.route.snapshot.paramMap.get('companyId');
    this.getCompany(id);
  }

  getCompany(id) {
    this.http.Get('/company/read/' + id).subscribe(
      data => {
        this.companyForm.patchValue(data.companies[0]);
        // this.companyForm = data.companies[0]

        // this.alert.Success('invoice is generated');
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  onSubmit(companyData) {
    // Process checkout data here
    this.http.Post('/company/edit', companyData).subscribe(
      data => {
        if (data.success) {
          this.alert.Success('Company is edited');
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
}


