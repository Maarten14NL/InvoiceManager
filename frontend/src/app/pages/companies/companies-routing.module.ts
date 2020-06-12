import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CompaniesComponent } from './companies.component';
import { IndexComponent } from './index/index.component';
import { SmartTableComponent } from './smart-table/smart-table.component';
import { TreeGridComponent } from './tree-grid/tree-grid.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [{
  path: '',
  component: CompaniesComponent,
  children: [
    {
      path: '',
      component: IndexComponent,
    },
    {
      path: 'create',
      component: CreateComponent,
    },
    {
      path: 'edit/:companyId',
      component: EditComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TablesRoutingModule { }

export const routedComponents = [
  CompaniesComponent,
  IndexComponent,
  CreateComponent,
  SmartTableComponent,
  TreeGridComponent,
  EditComponent,
];
