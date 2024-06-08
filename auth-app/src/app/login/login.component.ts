import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit(): void {
    const credentials = { email: this.email, password: this.password };
    this.authService.login(credentials).subscribe(response => {
      localStorage.setItem('token', response.token);
      this.router.navigate(['/']);
    }, error => {
      console.error('Login failed', error);
    });
  }
}
