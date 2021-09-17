import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-suppliers-index',
	template: `
		<div class="container">
			<h3 class="text-center">Suppliers</h3>
			<hr />
			<div class="">
				<app-supplier-form></app-supplier-form>
			</div>
			<div class="list">
				<app-suppliers-table></app-suppliers-table>
			</div>
		</div>
	`,
	styleUrls: ['./index.component.scss'],
})
export class IndexComponent implements OnInit {
	constructor() {}

	ngOnInit(): void {}
}
