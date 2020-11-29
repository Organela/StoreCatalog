import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Cd } from '../shared/cd.model';
import { CrudService } from './crud.service';

@Injectable({
    providedIn: 'root'
})
export class CdService extends CrudService<Cd> {   
 
constructor(http: HttpClient){
    super(http, 'cds');
 }
}