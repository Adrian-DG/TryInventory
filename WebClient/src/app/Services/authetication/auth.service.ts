import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

import { IRegister } from 'src/app/Interfaces/IRegister';
import { IResponse } from 'src/app/Interfaces/IResponse';
import { Observable } from 'rxjs';
import { ILogin } from 'src/app/Interfaces/ILogin';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	private endPoint: string = `${environment.api_url}/auth`;

	constructor(private $http: HttpClient, private $router: Router) {}

	Register(model: IRegister): Observable<IResponse> {
		return this.$http.post<IResponse>(`${this.endPoint}/register`, model);
	}

	// TODO: add a method to check the availability of a username

	Login(model: ILogin): void {
		this.$http
			.post<IResponse>(`${this.endPoint}/login`, model)
			.subscribe((resp) => {
				resp.status ? this.GiveAccess(resp) : console.log(resp.message);
			});
	}

	IsAutheticated(): boolean {
		const token = sessionStorage.getItem('token');
		return token == null ? false : true;
	}

	GoBack(): void {
		this.$router.navigate(['/']);
	}

	private GiveAccess(resp: IResponse): void {
		sessionStorage.setItem('token', resp.message); // save token to SessionStorage
		this.$router.navigate(['dashboard', resp.id]);
	}

	LogOut(): void {
		sessionStorage.clear();
		this.GoBack();
	}
}
