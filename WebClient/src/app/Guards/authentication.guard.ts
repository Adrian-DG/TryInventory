import { ThisReceiver } from '@angular/compiler';
import { Injectable } from '@angular/core';
import {
	ActivatedRouteSnapshot,
	CanActivate,
	RouterStateSnapshot,
	UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
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
