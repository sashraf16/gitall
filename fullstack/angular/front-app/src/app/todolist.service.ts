import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodolistService {

  private listurl = 'http://localhost:5000/api/values';

  constructor(private _httpService: HttpClient) { }

  apilist: string[] = [];

  getList() {
    // this._httpService.get('http://localhost:5000/api/values').subscribe(values => {this.apilist = values.json() as string[];
    // return of(this.apilist);
    return this._httpService.get<string[]>(this.listurl);
  }
}















