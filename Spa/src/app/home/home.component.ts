import { Component, OnInit } from '@angular/core';
import { register } from '../_models/register';
import { NgForm } from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { JwtHelperService } from "@auth0/angular-jwt";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  helper = new JwtHelperService();
  isLoggedin: boolean;
  toogleRegister: boolean = false;
  usuarioRegistrar: register = {
    usuario: '',
    cedula: '',
    clave: '',
    nombre: ''
  };
  constructor(private myService: AuthService, private myToastr: ToastrService) { }

  ngOnInit() {
    
  }


  cambiarRegister() {
    this.toogleRegister = !this.toogleRegister;
  }

  register(myForm: NgForm) {
    return this.myService.register(this.usuarioRegistrar).subscribe(
      () => { myForm.reset(); this.myToastr.success('Registro Ok'); }
    ), error => { this.myToastr.error('Ya existe usuario'); };
  }

}

