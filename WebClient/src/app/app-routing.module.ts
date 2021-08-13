import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './Pages/home/home.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';

const routes: Routes = [
	{ path: 'dashboard/{id}', component: DashboardComponent },
	{ path: 'home', component: HomeComponent },
	{ path: '', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
