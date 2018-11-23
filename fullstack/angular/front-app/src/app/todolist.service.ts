import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Todo } from './todo';
import { CATCH_ERROR_VAR } from '@angular/compiler/src/output/output_ast';

@Injectable({
  providedIn: 'root'
})
export class TodolistService {

  private listurl = 'http://localhost:5000/api/values';

  constructor(private _httpService: HttpClient) { }

  apilist: any;
  newTask: Todo = {
    id: 6,
    item: 'password'
  };

  getList() {
    // this._httpService.get('http://localhost:5000/api/values').subscribe(values => {this.apilist = values.json() as string[];
    // return of(this.apilist);
    return this._httpService.get<any>(this.listurl);
  }

  getTask(taskid) {
    const newurl = this.listurl + '/' + taskid;
    return this._httpService.get<any>(newurl);
  }

  insertTask(newTask) {
    return this._httpService.post<Todo>(this.listurl, newTask);
  }
}
















