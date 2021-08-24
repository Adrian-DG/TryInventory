import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/authetication/auth.service';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
	public isMenuCollapsed = true;
	isUserAuthenticated: boolean = false;

	constructor(private _auth: AuthService) {}

	checkUserStatus(): void {
		this.isUserAuthenticated = this._auth.IsAutheticated();
	}

	ngOnInit(): void {
		this.checkUserStatus();
	}
}
