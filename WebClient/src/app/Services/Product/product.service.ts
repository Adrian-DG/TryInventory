import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from '../../Interfaces/iproduct';
import { GenericService } from '../generic/generic.service';

@Injectable({
	providedIn: 'root',
})
export class ProductService extends GenericService<IProduct> {
	GetResourceUrl(): string {
		return 'products';
	}

	constructor(protected $http: HttpClient) {
		super($http);
	}
}
