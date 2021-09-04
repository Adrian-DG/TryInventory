import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthService } from '../Services/authetication/auth.service';

@Injectable({
	providedIn: 'root',
})
export class AuthenticationGuard implements CanActivate {
	constructor(private _auth: AuthService) {}

	canActivate(): boolean {
		let isAuthenticated = false;		
		this._auth.isAuthenticated$
		.subscribe(resp => isAuthenticated = resp);
		return isAuthenticated;
	}
}
