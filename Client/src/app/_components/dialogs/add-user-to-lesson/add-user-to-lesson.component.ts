import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { UserToAddLesson } from 'src/app/_models/userToAddLesson';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-add-user-to-lesson',
  templateUrl: './add-user-to-lesson.component.html',
  styleUrls: ['./add-user-to-lesson.component.scss']
})
export class AddUserToLessonComponent implements OnInit {

  lessonid: number;
  validationErrors: string[] = [];
  addUserForm: FormGroup;
  
  users: Observable<UserToAddLesson[]>;
  

  constructor( public _bsModalRef: BsModalRef,public lessonServices: LessonService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.intitializeForm();
    //
  }


  intitializeForm() {
    this.addUserForm = this.fb.group({
      userId: ["Válasz felhasználót!", Validators.required]
    });
    
    
  }

  addUser(){
    let userid = this.addUserForm.value.userId;
    this.lessonServices.addUserToLesson(userid,this.lessonid);
  }


}
