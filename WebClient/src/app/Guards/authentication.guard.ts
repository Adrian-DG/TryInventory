import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthService } from '../Services/authetication/auth.service';

@Injectable({
	providedIn: 'root',
})
export class AuthenticationGuard implements CanActivate {
	constructor(private _auth: AuthService) {}

	canActivate(): boolean {
		if (!this._auth.IsAutheticated()) {
			this._auth.GoBack();
			return false;
		}

		return true;
	}
}
