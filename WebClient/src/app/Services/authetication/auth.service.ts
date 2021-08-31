import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

import { IRegister } from 'src/app/Interfaces/IRegister';
import { IResponse } from 'src/app/Interfaces/IResponse';
import { Observable, Subject } from 'rxjs';
import { ILogin } from 'src/app/Interfaces/ILogin';
import { ToastrService } from '../Toastr/toastr.service';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	private endPoint: string = `${environment.api_url}/auth`;

	// TODO: implement Observable to check if user is authenticated
	private isUserAuthenticatedSource = new Subject<boolean>();
	public isUserAuthenticated$ = this.isUserAuthenticatedSource.asObservable();

	constructor(
		private $http: HttpClient,
		private $router: Router,
		private _toast: ToastrService
	) {}

	Register(model: IRegister): void {
		this.$http
			.post<IResponse>(`${this.endPoint}/register`, model)
			.subscribe((resp: IResponse) => {
				resp.status
					? this._toast.ShowSuccess({
							title: 'Registration successfull',
							message:
								'The registration process was completed successfully.',
					  })
					: this._toast.ShowFailure({
							title: 'Registration failed',
							message: resp.message,
					  });
			});
	}

	// TODO: add a method to check the availability of a username

	Login(model: ILogin): void {
		this.$http
			.post<IResponse>(`${this.endPoint}/login`, model)
			.subscribe((resp: IResponse) => {
				resp.status
					? this.GiveAccess(resp)
					: this._toast.ShowFailure({
							title: 'Login failed',
							message:
								'Something went wrong, check your credentials.',
					  });
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
		sessionStorage.setItem('username', resp.id);

		this.$router.navigate(['dashboard', resp.id]);
		this.isUserAuthenticatedSource.next(true);
		this._toast.ShowSuccess({
			title: 'Welcome',
			message: 'Welcome to TryInventory, start using it.',
		});
	}

	LogOut(): void {
		sessionStorage.clear();

		this.GoBack();
	}
}
