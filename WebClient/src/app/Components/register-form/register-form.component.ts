import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../Services/authetication/auth.service';
import { IResponse } from 'src/app/Interfaces/IResponse';

@Component({
	selector: 'app-register-form',
	templateUrl: './register-form.component.html',
	styleUrls: ['./register-form.component.scss'],
})
export class RegisterFormComponent implements OnInit {
	registerForm: FormGroup;

	constructor(private $fb: FormBuilder, private _auth: AuthService) {
		/* ----- initialize registerForm ------- */

		this.registerForm = this.$fb.group({
			firstname: ['', [Validators.required]],
			lastname: ['', [Validators.required]],
			doB: [],
			username: ['', [Validators.required]],
			phoneNumber: ['', [Validators.required]],
			emailAddress: ['', [Validators.required, Validators.email]],
			password: ['', [Validators.required, Validators.minLength(8)]],
			gender: [''],
		});
	}

	get form() {
		return this.registerForm.controls;
	}

	onSubmit(): void {
		// console.log(this.registerForm.value);
		this._auth.Register(this.registerForm.value);
	}

	clearForm(): void {
		this.registerForm.reset();
	}

	ngOnInit(): void {}
}
