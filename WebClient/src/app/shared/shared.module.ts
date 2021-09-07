import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
	declarations: [],
	imports: [
		CommonModule,
		ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
		BrowserAnimationsModule,
	],
})
export class SharedModule {}
