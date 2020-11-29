import { Component, OnInit } from '@angular/core';
import { element } from 'protractor';
import { BookService } from '../services/book.service';
import { CdService } from '../services/cd.service';
import { DvdService } from '../services/dvd.service';
import { Book } from '../shared/book.model';
import { Cd } from '../shared/cd.model';
import { Dvd } from '../shared/dvd.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  books: Book[];
  cds: Cd[];
  dvds: Dvd[];

  isBook = true;
  isCd = true;
  isDvd = true;
  isShowAll = true;

  constructor(readonly bookService: BookService,
    readonly cdService: CdService,
    readonly dvdService: DvdService) {
    this.load();
  }

  load() {
    this.bookService.getAll().subscribe(books => {
      this.books = books;
    });

    this.cdService.getAll().subscribe(cds => {
      this.cds = cds;
    });

    this.dvdService.getAll().subscribe(dvds => {
      this.dvds = dvds;
    });
  }

  ngOnInit(): void {

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

  deleteBook(book: any) {
    this.bookService.delete(book).subscribe(() => {
      this.load();
    });
  }

  deleteCd(cd: any) {
    this.cdService.delete(cd).subscribe(() => {
      this.load();
    });
  }

  deleteDvd(dvd: any) {
    this.dvdService.delete(dvd).subscribe(() => {
      this.load();
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLocaleLowerCase();

    if (filterValue == "") {
      this.load();
    }

      this.bookService.getAll().subscribe(() => {
        this.books = this.books.filter(book => {
          return book.title.toLocaleLowerCase().includes(filterValue)
        });
      });
    
      this.cdService.getAll().subscribe(() => {
        this.cds = this.cds.filter(cd => {
          return cd.title.toLocaleLowerCase().includes(filterValue)
        });
      });

      this.dvdService.getAll().subscribe(() => {
        this.dvds = this.dvds.filter(dvd => {
          return dvd.title.toLocaleLowerCase().includes(filterValue)
        });
      });
  }

}
