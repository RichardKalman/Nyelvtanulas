import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-lesson-delete',
  templateUrl: './lesson-delete.component.html',
  styleUrls: ['./lesson-delete.component.scss']
})
export class LessonDeleteComponent implements OnInit {

  id:number;
  navigate: boolean;

  constructor(public _bsModalRef: BsModalRef, private lessonService: LessonService,private router: Router) { }

  ngOnInit(): void {
  }

  delete(){

    this.lessonService.deleteLesson(this.id);
    this._bsModalRef.hide();
    if(this.navigate){
      this.router.navigateByUrl("/lessons");
    }
  }

}
