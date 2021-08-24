import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/authetication/auth.service';
import { Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/ILogin';
import { IResponse } from 'src/app/Interfaces/IResponse';

@Component({
	selector: 'app-login-form',
	templateUrl: './login-form.component.html',
	styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent implements OnInit {
	username: string = '';
	password: string = '';

	constructor(private _auth: AuthService, private $router: Router) {}

	OnSubmit(): void {
		this._auth
			.Login({ username: this.username, password: this.password })
			.subscribe((resp: IResponse) =>
				resp.status
					? this.$router.navigate(['dashboard', resp.id])
					: console.log(resp.message)
			);
	}

	ngOnInit(): void {}
}
