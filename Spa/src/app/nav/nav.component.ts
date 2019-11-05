import { Component, OnInit } from '@angular/core';
import { login } from '../_models/login';
import { NgForm } from '@angular/forms';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styles: []
})
export class NavComponent implements OnInit {
  loginUsuario: login = {
    usuario: '',
    clave: ''
  };
  constructor(private myService: AuthService) { }

  login(myForm: NgForm) {
    return this.myService.login(this.loginUsuario).subscribe(
      () => { myForm.reset(); }
    );
  }

  ngOnInit() {
  }

}
