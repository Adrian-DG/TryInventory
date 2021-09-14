import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { AsyncSubject, Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export abstract class GenericService<T> {
	private readonly endPoint: string =
		environment.api_url + '/' + this.GetResourceUrl();

	private listOfTypeSource = new AsyncSubject();
	public listOfType$ = this.listOfTypeSource.asObservable();

	constructor(protected $http: HttpClient) {}

	abstract GetResourceUrl(): string;

	GetAll(): void {
		this.$http.get<T[]>(this.endPoint)
		.subscribe((data: T[]) => this.listOfTypeSource.next(data));
	}

	GetById(id: string): Observable<T> {
		return this.$http.get<T>(this.endPoint + '/' + id);
	}

	Post(model: T): void {
		this.$http
			.post<Object>(this.endPoint + '/create', model)
			.subscribe((resp) => console.log(resp));
	}

	Update(model: T): void {
		this.$http
			.put<Object>(this.endPoint + '/edit', model)
			.subscribe((resp) => console.log(resp));
	}

	Delete(id: string): void {
		this.$http
			.delete<Object>(this.endPoint + '/remove/' + id)
			.subscribe((resp) => console.log(resp));
	}
}
