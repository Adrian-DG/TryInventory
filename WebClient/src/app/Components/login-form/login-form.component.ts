import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/authetication/auth.service';
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

	constructor(private _auth: AuthService) {}

	OnSubmit(): void {
		this._auth.Login({ username: this.username, password: this.password });
		this.ClearForm();
	}

	ClearForm(): void {
		this.username = '';
		this.password = '';
	}

	ngOnInit(): void {}
}
