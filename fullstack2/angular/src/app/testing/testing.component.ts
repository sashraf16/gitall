import { Component, OnInit } from '@angular/core';
import { UserService } from './../user.service';

@Component({
  selector: 'app-testing',
  templateUrl: './testing.component.html',
  styleUrls: ['./testing.component.css']
})
export class TestingComponent implements OnInit {

  allusers = [];

  constructor(private usrs: UserService) { }

  ngOnInit() {
    this.usrs.getallusers().subscribe(users => this.allusers = users);
  }

}
