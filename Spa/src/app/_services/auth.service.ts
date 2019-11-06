import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { register } from '../_models/register';
import { map } from 'rxjs/operators';
import { login } from '../_models/login';
import { token } from '../_models/token';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor(private myHttp: HttpClient) { }
  baseUrl = "http://localhost:5000/api/auth"

  register(myModel: register) {
    return this.myHttp.post(this.baseUrl + '/register', myModel).pipe(
      map(
        () => { console.log('Registro'); }
      )
    );
  }

  login(myModel: login) {
    return this.myHttp.post(this.baseUrl + '/login', myModel).pipe(
      map(
        (response: token) => {  localStorage.setItem('Token', response.myToken); }
      )
    );
  }
}

