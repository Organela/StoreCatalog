import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductListComponent } from './product-list/product-list.component';

const routes: Routes = [
  {
    path: '',
    component: ProductListComponent,  
  },
  {
    path: 'book/new',
    component: ProductEditComponent
  },
  {
    path: 'cd/new',
    component: ProductEditComponent
  },
  {
    path: 'dvd/new',
    component: ProductEditComponent
  },
  {
    path: 'book/:id/edit',
    component: ProductEditComponent
  },
  {
    path: 'cd/:id/edit',
    component: ProductEditComponent
  },
  {
    path: 'dvd/:id/edit',
    component: ProductEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
