import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { HttpService } from '../../../services/http.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './smart-table.component.html',
  styleUrls: ['./smart-table.component.scss'],
})
export class SmartTableComponent {

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmCreate: true,
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmSave: true,
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      // Id: {
      //   title: 'ID',
      //   type: 'none',
      // },
      Name: {
        title: 'Name',
        type: 'string',
      },
      Description: {
        title: 'Description',
        type: 'text',
      },
      Price: {
        title: 'Price',
        type: 'double',
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(
    private http: HttpService,
    private alert: AlertService,
  ) {
    this.http.Get('https://localhost:44372/contract').subscribe(
      data => {
        this.source.load(data.contracts);

        // this.alert.Success('invoice is generated');
      },
      err => {
        this.alert.Error(err.message);
      },
    );
  }

  onCreateConfirm( event ): void {
    const contract = event.newData;
    if ( contract.Name && contract.Description && contract.Price ) {
      this.http.Post('https://localhost:44372/contract/create', contract).subscribe(
        data => {
          this.alert.Success('invoice is generated');
        },
        err => {
          this.alert.Error(err.message);
        },
      );
    }
  }

  onEditConfirm( event ): void {
    const contract = event.newData;
    if (event.data !== contract) {
      if ( contract.Name && contract.Description && contract.Price ) {
        this.http.Post('https://localhost:44372/contract/edit', contract).subscribe(
        data => { this.alert.Success('invoice is generated'); },
        err => { this.alert.Error(err.message); },
      );
      }
    }
  }

  onDeleteConfirm( event ): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
      this.http.Post('https://localhost:44372/contract/delete', event.data).subscribe(
        data => {
          this.alert.Success('invoice is generated');
        },
        err => {
          this.alert.Error(err.message);
        },
      );
    } else {
      event.confirm.reject();
    }
  }
}
