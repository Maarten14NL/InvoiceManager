import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  NbAccordionModule,
  NbButtonModule,
  NbCardModule,
  NbListModule,
  NbSpinnerModule,
  NbRouteTabsetModule,
  NbStepperModule,
  NbTabsetModule, NbUserModule,
  NbCheckboxModule,
} from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { GenerateRoutingModule } from './generate-routing.module';
import { GenerateComponent } from './generate.component';
import { InvoiceComponent } from './invoice/invoice.component';
// import { AccordionComponent } from './accordion/accordion.component';
// import { NewsService } from './news.service';

@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ThemeModule,
    NbTabsetModule,
    NbRouteTabsetModule,
    NbStepperModule,
    NbCardModule,
    NbButtonModule,
    NbSpinnerModule,
    NbListModule,
    NbAccordionModule,
    NbUserModule,
    GenerateRoutingModule,
    NbCheckboxModule,
  ],
  declarations: [
    InvoiceComponent,
    GenerateComponent,
  ],
})
export class GenerateModule { }
