import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UserdetailsComponent } from './_components/userdetails/userdetails.component';
import { UserlistComponent } from './_components/userlist/userlist.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: AppComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'users', component: UserlistComponent, canActivate: [AuthGuard]},
      {path: 'users/:id', component: UserdetailsComponent},
      
    ]
  },
  {path: '**', component: AppComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
