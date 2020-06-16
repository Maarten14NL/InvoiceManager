import { Component } from '@angular/core';

import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './company-contracts.component.html',
  styleUrls: ['./company-contracts.component.scss'],
})
export class CompanyContractsComponent {

  id;
  company;
  companyContracts;
  contracts;

  newCompanyContract;

  constructor(
    private http: HttpService,
    private alert: AlertService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
  ) {
    this.id = this.route.snapshot.paramMap.get('companyId');
    this.getCompany(this.id);
    this.GetCompanyContracts(this.id);
    this.GetContracts();

    this.newCompanyContract = this.formBuilder.group({
      Id: 0,
      Company: this.company,
      Contract: {},
      Amount: 0,
      StartDate: '',
      EndDate: '',
    });
  }

  getCompany(id) {
    this.http.Get('/company/read/' + id).subscribe(
      data => {
        this.company = data.companies;

      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  GetContracts() {
    this.http.Get('/contract/read').subscribe(
      data => {
        this.contracts = data.contracts;
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  GetCompanyContracts(id) {
    this.http.Get('/companycontract/bycompany/' + id).subscribe(
      data => {
        this.companyContracts = data.companyContracts;
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  onSubmit(newContractData) {
    // Process checkout data here
    newContractData.Company = this.company[0];

    this.http.Post('/companycontract/create', newContractData).subscribe(
      data => {
        if (data.success) {
          this.alert.Success('Contract is added too company');
          this.GetCompanyContracts(this.id);
        } else {
          this.alert.Error('Contract is NOT added too company');
        }
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  Edit(companyContract) {
    companyContract.Company = this.company[0];

    this.http.Post('/companycontract/update', companyContract).subscribe(
      data => {
        if (data.success) {
          this.alert.Success('Company is edited');
        } else {
          this.alert.Error('Company is NOT created');
        }
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  delete( item ): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.http.Post('/company/delete', item).subscribe(
        data => {
          this.alert.Success('invoice is generated');
          this.GetCompanyContracts(1);
        },
        err => {
          this.alert.Error(err.message);
        },
      );
    }
  }
}


