import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

/* ----- modules ---------- */

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';

/* --- components ------*/

import { NavbarComponent } from './Components/navbar/navbar.component';
import { HomeComponent } from './Pages/home/home.component';
import { RegisterFormComponent } from './Components/register-form/register-form.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { LoginFormComponent } from './Components/login-form/login-form.component';

import { AuthInterceptorService } from './Services/authInterceptor/auth-interceptor.service';
import { TableComponent } from './Components/supplier/table/table.component';
import { IndexComponent } from './Components/supplier/index/index.component';

@NgModule({
	declarations: [
		AppComponent,
		NavbarComponent,
		HomeComponent,
		RegisterFormComponent,
		DashboardComponent,
		LoginFormComponent,
  TableComponent,
  IndexComponent,
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		NgbModule,
		HttpClientModule,
		ReactiveFormsModule,
		FormsModule,
		SharedModule,
	],
	providers: [
		{
			provide: HTTP_INTERCEPTORS,
			useClass: AuthInterceptorService,
			multi: true,
		},
	],
	bootstrap: [AppComponent],
})
export class AppModule {}
