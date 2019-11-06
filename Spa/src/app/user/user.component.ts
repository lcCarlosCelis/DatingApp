import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';
import { users } from '../_models/users';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: []
})
export class UserComponent implements OnInit {
  usersList: users[] = [{
    nombreCompleto: '',
    url: ''
  }];
  constructor(private myService: UserService) { }

  ngOnInit() {
    this.myService.getUsers().subscribe(
      (response: users[]) => { this.usersList = response; console.log(response); }
    ), error => { console.log('Error'); };
  }
}

