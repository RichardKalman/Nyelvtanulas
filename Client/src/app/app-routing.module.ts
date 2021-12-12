import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { AdminPanelComponent } from './_components/admin/admin-panel/admin-panel.component';
import { DoLessonComponent } from './_components/doLesson/do-lesson/do-lesson.component';
import { LessonCreateComponent } from './_components/lesson/lesson-create/lesson-create.component';
import { LessonDetailsComponent } from './_components/lesson/lesson-details/lesson-details.component';
import { LessonListComponent } from './_components/lesson/lesson-list/lesson-list.component';
import { MyLessonsComponent } from './_components/lesson/my-lessons/my-lessons.component';
import { MyResultsComponent } from './_components/lesson/my-results/my-results.component';
import { UserEditComponent } from './_components/user-edit/user-edit.component';
import { UserdetailsComponent } from './_components/userdetails/userdetails.component';
import { UserlistComponent } from './_components/userlist/userlist.component';
import { WordListComponent } from './_components/word-list/word-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';

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
      {path: 'lessons',component: LessonListComponent},
      {path: 'lesson/add',component: LessonCreateComponent},
      {path: 'lessons/:id',component: LessonDetailsComponent},
      {path: 'doLesson/:userId/:lessonId', component: DoLessonComponent},
      {path: 'mylesson/:userId', component: MyLessonsComponent},
      {path: 'myresult/:userId', component: MyResultsComponent},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},
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
