import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

import { IRegister } from 'src/app/Interfaces/IRegister';
import { IResponse } from 'src/app/Interfaces/IResponse';
import { BehaviorSubject, Observable, ReplaySubject, Subject } from 'rxjs';
import { ILogin } from 'src/app/Interfaces/ILogin';
import { ToastrService } from '../Toastr/toastr.service';
import { IUser } from 'src/app/Interfaces/iuser';
import { ILoginResponse } from 'src/app/Interfaces/ilogin-response';

@Injectable({
	providedIn: 'root',
})
export class AuthService {
	private endPoint: string = `${environment.api_url}/auth`;
	private currentUserSource = new ReplaySubject<IUser | null>(1);
	public currentUser$ = this.currentUserSource.asObservable();
	private isAuthenticatedSource = new BehaviorSubject<boolean>(false);
	public isAuthenticated$ = this.isAuthenticatedSource.asObservable();

	constructor(
		private $http: HttpClient,
		private $router: Router,
		private _toast: ToastrService
	) {}

	private FormatMessage(model: IResponse): void {
		model.status 
		? this._toast.ShowSuccess({ title: 'Process succeed', message: model.message })
		: this._toast.ShowFailure({ title: 'Process failed', message: model.message});
	}

	private GiveAccess(model: IUser): void {
		sessionStorage.setItem('userId', model.userId);
		sessionStorage.setItem('username', model.username);
		sessionStorage.setItem('token', model.token);
		this.isAuthenticatedSource.next(true);
		this.currentUserSource.next({ userId: model.userId, username: model.username, token: model.token });
		this.$router.navigate(['dashboard', model.username]);
		this.FormatMessage({ id: '', message: 'login proccess was successful', status: true });
	}

	CheckStatus(): void {
		const username = sessionStorage.getItem("username");
		if ( username != null) {
			this.isAuthenticatedSource.next(true);
			this.$router.navigate(['dashboard', username]);
		} 
		else {
			this.isAuthenticatedSource.next(false); 
		}
	}

	GetCurrentUser(): void {
		const { userId, username, token } = sessionStorage;		
		(username != null && token != null)
		? this.currentUserSource.next({ userId ,username, token })
		: this.currentUserSource.next();
	}

	Register(model: IRegister): void {
		this.$http.post<IResponse>(`${this.endPoint}/register`, model)
		.subscribe((resp: IResponse) =>  this.FormatMessage(resp));
	}

	Login(model: ILogin): void {
		this.$http.post<ILoginResponse>(`${this.endPoint}/login`, model)
		.subscribe((resp: ILoginResponse) => {
			resp.status 
			? this.GiveAccess({ userId: resp.userId, username: resp.username, token: resp.token }) 
			: this.FormatMessage({ id: '', message: 'login proccess failed, check credentials', status: false });
		});
	}
	
	LogOut(): void {
		sessionStorage.clear();
		this.currentUserSource.next();
		this.isAuthenticatedSource.next(false);
		this.$router.navigateByUrl("/");		
	}
}
