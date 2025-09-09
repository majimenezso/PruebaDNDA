import { Component } from '@angular/core';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core'
import { CommonModule } from '@angular/common'
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { formatDate } from '@angular/common';
import { User } from './../../../interfaces/User';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import 'sweetalert2/src/sweetalert2.scss';

@Component({
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class LoginComponent {
  loginForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private ApiService: ApiService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: [
        '',
        [Validators.required, Validators.minLength(4), Validators.maxLength(20)]
      ],
      password: [
        '',
        [Validators.required, Validators.minLength(6), Validators.maxLength(20)]
      ]
    });
  }

  Login() {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;
      this.ApiService.login(username, password).subscribe({
      next: (res) => {
        Swal.fire({
          title: 'Bienvenido',
          text: '',
          icon: 'success',
          timer: 1500,
          showConfirmButton: false
        });

        this.router.navigate(['/home']);
      },
      error: () => {
        this.showModalError();
      }
    });
    }
  }

  showModalError() {
    Swal.fire({
      title: 'Ha ocurrido un error',
      text: 'No se pudo conectar con el servidor. Usuario o contraseña incorrectos.',
      icon: 'error',
      confirmButtonColor: '#dc3545',
      confirmButtonText: 'Aceptar'
    });
  }

  resetForm() {
    this.loginForm.reset();
  }
   
}
