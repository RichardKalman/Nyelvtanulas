import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './_components/navbar/navbar.component';
import { LoginComponent } from './_components/login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './_components/register/register.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './_modules/shared/shared.module';
import { UserlistComponent } from './_components/userlist/userlist.component';
import { UserdetailsComponent } from './_components/userdetails/userdetails.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { UserTableRowComponent } from './_components/user-table-row/user-table-row.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { UserEditComponent } from './_components/user-edit/user-edit.component';
import { NgxSpinnerModule } from 'ngx-spinner'
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { WordListComponent } from './_components/word-list/word-list.component';
import { DeleteDialogComponent } from './_components/dialogs/delete-dialog/delete-dialog.component';
import { AddWordComponent } from './_components/dialogs/add-word/add-word.component';
import { UpdateWordComponent } from './_components/dialogs/update-word/update-word.component';
import { LessonListComponent } from './_components/lesson/lesson-list/lesson-list.component';
import { LessonCreateComponent } from './_components/lesson/lesson-create/lesson-create.component';
import { LessonSelectListComponent } from './_components/lesson/lesson-select-list/lesson-select-list.component';
import { LessonDetailsComponent } from './_components/lesson/lesson-details/lesson-details.component';
import { LessonEditComponent } from './_components/lesson/lesson-edit/lesson-edit.component';
import { LessonDeleteComponent } from './_components/dialogs/lesson-delete/lesson-delete.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    UserlistComponent,
    UserdetailsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorsComponent,
    UserTableRowComponent,
    UserEditComponent,
    DateInputComponent,
    TextInputComponent,
    WordListComponent,
    DeleteDialogComponent,
    AddWordComponent,
    UpdateWordComponent,
    LessonListComponent,
    LessonCreateComponent,
    LessonSelectListComponent,
    LessonDetailsComponent,
    LessonEditComponent,
    LessonDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
