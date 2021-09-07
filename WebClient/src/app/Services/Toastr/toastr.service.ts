import { Injectable } from '@angular/core';

import { IToastMessage } from '../../Interfaces/itoast-message';
import { ToastrService as Toast } from 'ngx-toastr';

@Injectable({
	providedIn: 'root',
})
export class ToastrService {
	constructor(private _toast: Toast) {}

	ShowSuccess(model: IToastMessage): void {
		this._toast.success(model.message, model.title, { timeOut: 3000 });
	}

	ShowFailure(model: IToastMessage): void {
		this._toast.error(model.message, model.title, { timeOut: 3000 });
	}
}
