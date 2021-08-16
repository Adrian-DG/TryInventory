import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

	constructor(private $http: HttpClient) {}

	Register(model: IRegister): Observable<IResponse> {
		return this.$http.post<IResponse>(`${this.endPoint}/register`, model);
	}

	Login(model: ILogin): Observable<IResponse> {
		return this.$http.post<IResponse>(`${this.endPoint}/login`, model);
	}
}
