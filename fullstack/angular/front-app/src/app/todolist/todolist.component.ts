import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TodolistService } from './../todolist.service';


@Component({
  selector: 'app-todolist',
  templateUrl: './todolist.component.html',
  styleUrls: ['./todolist.component.css']
})
export class TodolistComponent implements OnInit {

  list = ['hello', 'test', 'another'];
  apilist: string[] = [];
  holder = '';
  constructor(private listservice: TodolistService) { }

  ngOnInit() {
    this.getList();
  }

  addItem() {
    this.list.push(this.holder);
    this.holder = '';
  }

  getList() {
    // this.apilist.push('hello');
    this.listservice.getList()
      .subscribe(items => this.apilist = items);
  }
}
