import { Component, OnInit } from '@angular/core';
import { login } from '../_models/login';
import { NgForm } from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { JwtHelperService } from "@auth0/angular-jwt";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: []
})
export class NavComponent implements OnInit {
  helper = new JwtHelperService();
  estaLoggeado: boolean = false;
  username: string;
  decodedToken: any;
  loginUsuario: login = {
    usuario: '',
    clave: ''
  };
  constructor(private myService: AuthService, private myToastr: ToastrService,
    private myRouter: Router) { }

  login(myForm: NgForm) {
    return this.myService.login(this.loginUsuario).subscribe(
      () => { myForm.reset(); 
        this.myToastr.success('Ok login');
        this.isLoggedin(); }
    );
  }

  isLoggedin() {
    if(!this.helper.isTokenExpired(localStorage.getItem('Token')))
    { 
      this.estaLoggeado = true; 
      this.decodedToken = this.helper.decodeToken(localStorage.getItem('Token'));
      this.username = this.decodedToken.unique_name;
    }else {
      this.estaLoggeado = false; 
    }
  }

  ngOnInit() {
    this.isLoggedin();
  }

  cerrar() {
    localStorage.removeItem('Token');
    this.isLoggedin();
    this.myRouter.navigate(['/home']);
  }
}
