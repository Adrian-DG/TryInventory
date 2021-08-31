import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/authetication/auth.service';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
	public isMenuCollapsed = true;
	isUserAuthenticated: boolean = false; // TODO: listen to isAuthenticated observable
	username: string | null = null;

	constructor(private _auth: AuthService) {}

	checkUserStatus(): void {
		this.isUserAuthenticated = this._auth.IsAutheticated();
		if (this.isUserAuthenticated) {
			this.username = sessionStorage.getItem('username');
		}
	}

	LogOut(): void {
		this._auth.LogOut();
	}

	ngOnInit(): void {
		this.checkUserStatus();
	}
}
