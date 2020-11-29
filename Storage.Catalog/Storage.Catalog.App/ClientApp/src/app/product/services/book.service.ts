import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Book } from '../shared/book.model';
import { CrudService } from './crud.service';

@Injectable({
    providedIn: 'root'
})
export class BookService extends CrudService<Book> {   
 
constructor(http: HttpClient){
    super(http, 'books');
 }
}