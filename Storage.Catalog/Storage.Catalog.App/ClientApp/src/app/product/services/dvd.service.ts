import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Dvd } from '../shared/dvd.model';
import { CrudService } from './crud.service';

@Injectable({
    providedIn: 'root'
})
export class DvdService extends CrudService<Dvd> {   
 
constructor(http: HttpClient){
    super(http, 'dvds');
 }
}