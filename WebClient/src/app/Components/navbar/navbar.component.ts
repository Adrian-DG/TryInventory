import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/Interfaces/iuser';
import { AuthService } from '../../Services/authetication/auth.service';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
	public isMenuCollapsed = true;
	isUserAuthenticated$ = this._auth.isAuthenticated$;
	currentUser$ = this._auth.currentUser$;

	constructor(private _auth: AuthService) {}

	LogOut(): void {
		this._auth.LogOut();
	}

	ngOnInit(): void {
		this._auth.CheckStatus();
		this._auth.GetCurrentUser();
	}
}
