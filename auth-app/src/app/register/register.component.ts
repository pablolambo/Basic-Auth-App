import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit(): void {
    const user = { email: this.email, password: this.password };
    this.authService.register(user).subscribe(response => {
      this.router.navigate(['/login']);
    }, error => {
      console.error('Registration failed', error);
    });
  }
}
