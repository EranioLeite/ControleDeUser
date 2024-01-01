import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm = this.fb.group({
    usuario: ['', Validators.required],
    senha: ['', Validators.required]
  });
  constructor(private fb: FormBuilder, private loginserve: LoginService, private router: Router) {}

  onSubmit(values:any) {
    this.loginserve.acessarSistema(values).subscribe(_ => this.router.navigate(['']))
    
  }
}
