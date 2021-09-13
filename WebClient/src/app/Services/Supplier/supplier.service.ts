import { Injectable } from '@angular/core';
import { ISupplier } from '../../Interfaces/isupplier';
import { GenericService } from '../generic/generic.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class SupplierService extends GenericService<ISupplier> {
	constructor(protected $http: HttpClient) {
		super($http);
	}

	GetResourceUrl(): string {
		return 'suppliers';
	}
}
