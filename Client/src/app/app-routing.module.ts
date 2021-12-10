import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { LessonListComponent } from './_components/lesson/lesson-list/lesson-list.component';
import { UserEditComponent } from './_components/user-edit/user-edit.component';
import { UserdetailsComponent } from './_components/userdetails/userdetails.component';
import { UserlistComponent } from './_components/userlist/userlist.component';
import { WordListComponent } from './_components/word-list/word-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  {path: '', component: AppComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'users', component: UserlistComponent},
      {path: 'users/:username', component: UserdetailsComponent},
      {path: 'user/edit', component: UserEditComponent},
      {path: 'words', component: WordListComponent},
      {path: 'lessons',component: LessonListComponent}
    ]
  },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
