import { NgModule } from '@angular/core';
import {
  NbCardModule,
  NbIconModule,
  NbInputModule,
  NbTreeGridModule,
  NbButtonModule,
  NbDatepickerModule,
  NbSelectModule,
} from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';
import { TablesRoutingModule, routedComponents } from './companies-routing.module';
import { FsIconComponent } from './tree-grid/tree-grid.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatepickerComponent } from '../forms/datepicker/datepicker.component';


@NgModule({
  imports: [
    NbCardModule,
    NbTreeGridModule,
    NbIconModule,
    NbInputModule,
    NbButtonModule,
    ThemeModule,
    TablesRoutingModule,
    Ng2SmartTableModule,
    FormsModule,
    ReactiveFormsModule,
    NbDatepickerModule,
    NbSelectModule,
  ],
  declarations: [
    ...routedComponents,
    FsIconComponent,
    DatepickerComponent,
  ],
})
export class CompaniesModule { }
