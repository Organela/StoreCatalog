import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';

import { ProductRoutingModule } from './product-routing.module';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductListComponent } from './product-list/product-list.component';

@NgModule({
  declarations: [
    ProductEditComponent,
    ProductListComponent
  ],
  imports: [
    ProductRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatMenuModule,
    CommonModule
  ]
})
export class ProductModule { }
