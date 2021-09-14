import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-suppliers-index',
	template: `
		<div class="container">
			<h3 class="text-center">Suppliers</h3>
			<hr />
			<div class="">
				<h5 class="text-center">formulary goes here</h5>
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
