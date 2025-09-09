import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../../interfaces/User';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-home',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HomeComponent {
  users: User[] = [];
  loading = true;

  constructor(private http: HttpClient,  private ApiService: ApiService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    const token = localStorage.getItem('token');

    if (!token) {
      this.loading = false;
      return;
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    this.loading = true;

  this.ApiService.getUsers().subscribe({
    next: (res) => {
      this.users = res.users ? res.users : res; 
      this.loading = false;
    },
    error: () => {
      this.loading = false;
    }
  });
}
}
