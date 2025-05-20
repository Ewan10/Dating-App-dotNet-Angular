import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user.model';
import { map } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = environment.url;
  currentUser = signal<User | null>(null);

  login(user: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', user).pipe(
      map(user => {
        console.log("account service login: ", this.baseUrl + 'account/login');
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
  }

  register(user: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', user).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
