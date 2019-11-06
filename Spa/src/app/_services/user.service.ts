import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { users } from '../_models/users';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = "http://localhost:5000/api/user";
  constructor(private myHttp: HttpClient) { }

  getUsers() {
    return this.myHttp.get<users[]>(this.baseUrl, { headers: 
      new HttpHeaders().set('Authorization', 'Bearer ' + localStorage.getItem('Token')) });
  }
}
