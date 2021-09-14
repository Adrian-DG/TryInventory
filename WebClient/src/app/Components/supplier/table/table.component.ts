import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/Services/Supplier/supplier.service';
import { ISupplier } from 'src/app/Interfaces/isupplier';
import { Observable } from 'rxjs';

@Component({
	selector: 'app-suppliers-table',
	templateUrl: './table.component.html',
	styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
	constructor(private _supplier: SupplierService) {}

	suppliers: Observable<ISupplier[]> | any = this._supplier.listOfType$;

	ngOnInit(): void {
		this._supplier.GetAll();
	}
}
