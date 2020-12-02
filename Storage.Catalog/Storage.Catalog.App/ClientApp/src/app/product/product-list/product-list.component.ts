import { Component } from '@angular/core';

import { BookService } from '../services/book.service';
import { CdService } from '../services/cd.service';
import { CrudService } from '../services/crud.service';
import { DvdService } from '../services/dvd.service';
import { Book } from '../shared/book.model';
import { Cd } from '../shared/cd.model';
import { Dvd } from '../shared/dvd.model';
import { Product } from '../shared/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent {
  private allBooks: Book[];
  private allCds: Cd[];
  private allDvds: Dvd[];
  private productServiceMap: {[key: string]: CrudService<any>};
  private filterValue: string;

  filteredBooks: Book[];
  filteredCds: Cd[];
  filteredDvds: Dvd[];

  isBook = true;
  isCd = true;
  isDvd = true;
  isShowAll = true;

  constructor(bookService: BookService,
              cdService: CdService,
              dvdService: DvdService) {
    this.productServiceMap = {
      "Books": bookService,
      "Cds": cdService,
      "Dvds": dvdService
    };

    this.load();
  }

  load() {
    for (let key of Object.keys(this.productServiceMap)) {
      const service = this.productServiceMap[key];
      service.getAll().subscribe(products => {
        this[`all${key}`] = products;
        this[`filtered${key}`] = products;
      });
    }
  }

  setShowAll() {
    this.isShowAll = true
  }

  setShowBooks() {
    this.isBook = true;
    this.isCd = false;
    this.isDvd = false;
    this.isShowAll = false;
  }

  setShowCds() {
    this.isBook = false;
    this.isCd = true;
    this.isDvd = false;
    this.isShowAll = false;
  }

  setShowDvds() {
    this.isBook = false;
    this.isCd = false;
    this.isDvd = true;
    this.isShowAll = false;
  }

  delete(productType: string, product: Product) {
    this.productServiceMap[productType].delete(product).subscribe(() => {
      const products = this[`all${productType}`];
      products.splice(products.indexOf(product), 1);
      this.applyFilter(this.filterValue);
    });
  }

  applyFilter(filterValue: string) {
    this.filterValue = filterValue;

    for (let key of Object.keys(this.productServiceMap)) {
      const allProducts = this[`all${key}`];
      this[`filtered${key}`] = allProducts.filter(product => product.title.toLocaleLowerCase().includes(filterValue || ''));
    }
  }
}
