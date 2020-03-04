import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GenerateComponent } from './generate.component';
import { InvoiceComponent } from './invoice/invoice.component';

const routes: Routes = [{
  path: '',
  component: GenerateComponent,
  children: [
    {
      path: 'invoice',
      component: InvoiceComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GenerateRoutingModule {
}
