import { Component, OnInit } from '@angular/core';
import { TodolistService } from './../todolist.service';
import { Todo } from '../todo';

@Component({
  selector: 'app-todoform',
  templateUrl: './todoform.component.html',
  styleUrls: ['./todoform.component.css']
})
export class TodoformComponent implements OnInit {

  accounts = ['personal', 'business', 'temporary'];

  model: any;
  newmodel: any;

  constructor(private listservice: TodolistService) { }

  getTask (taskId) {
    this.listservice.getTask(taskId).subscribe(task => console.log(task));
  }

  ngOnInit() {
    this.getTask(3);

    // console.log(this.model);
    // this.newmodel = new Todo(this.model.id, this.model.name);
    // console.log(this.model);
  }

}
