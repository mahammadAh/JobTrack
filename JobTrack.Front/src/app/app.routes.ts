import { Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { ClientComponent } from './components/client/client.component';

export const routes: Routes = [
    { path: 'admin', component: AdminComponent }, 
    { path: 'vacancy', component: ClientComponent },         
    { path: '', redirectTo: '/admin', pathMatch: 'full' },            
  ];
