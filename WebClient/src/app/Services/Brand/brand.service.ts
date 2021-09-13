import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from 'src/app/Interfaces/ibrand';
import { GenericService } from '../generic/generic.service';

@Injectable({
	providedIn: 'root',
})
export class BrandService extends GenericService<IBrand> {
	GetResourceUrl(): string {
		return 'brands';
	}

	constructor(protected $http: HttpClient) {
		super($http);
	}
}
