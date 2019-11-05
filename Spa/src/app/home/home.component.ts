import { Component, OnInit } from '@angular/core';
import { register } from '../_models/register';
import { NgForm } from '@angular/forms';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  toogleRegister: boolean = false;
  usuarioRegistrar: register = {
    usuario: '',
    cedula: '',
    clave: '',
    nombre: ''
  };
  constructor(private myService: AuthService) { }

  ngOnInit() {
  }

  cambiarRegister() {
    this.toogleRegister = !this.toogleRegister;
  }

  register(myForm: NgForm) {
    return this.myService.register(this.usuarioRegistrar).subscribe(
      () => { myForm.reset(); }
    ), error => { console.log('Error'); };
  }

}

