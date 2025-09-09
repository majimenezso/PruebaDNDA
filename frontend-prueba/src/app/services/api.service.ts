import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:5137/api/pruebatecnica/users';
  private jwtToken: string | null = null;


  constructor(private http: HttpClient) {}


  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/login`, { username, password })
      .pipe(
        tap(response => {
          this.jwtToken = response.jwt;
          localStorage.setItem('jwt', response.jwt);
        })
      );
  }

  getUsers(): Observable<any> {
    if (!this.jwtToken) {
      this.jwtToken = localStorage.getItem('jwt');
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.jwtToken}`
    });

    return this.http.get<any>(this.baseUrl, { headers });
  }
}
