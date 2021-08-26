import { Injectable } from '@angular/core';
import {
	HttpInterceptor,
	HttpRequest,
	HttpHandler,
	HttpEvent,
	HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
	providedIn: 'root',
})
export class AuthInterceptorService implements HttpInterceptor {
	constructor(private $router: Router) {}

	intercept(
		req: HttpRequest<any>,
		next: HttpHandler
	): Observable<HttpEvent<any>> {
		const token: string | null = sessionStorage.getItem('token');

		let request = req;

		if (token) {
			request = req.clone({
				setHeaders: { authorization: `Bearer ${token}` },
			});
		}

		return next.handle(request).pipe(
			catchError((error: HttpErrorResponse) => {
				if (error.status === 401) {
					this.$router.navigate(['/']);
				}

				return throwError(error);
			})
		);
	}
}
