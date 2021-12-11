import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { LessonService } from 'src/app/_services/lesson.service';
import { Lesson } from '../../../_models/lesson';
import { LessonDeleteComponent } from '../../dialogs/lesson-delete/lesson-delete.component';

@Component({
  selector: 'app-lesson-list',
  templateUrl: './lesson-list.component.html',
  styleUrls: ['./lesson-list.component.scss']
})
export class LessonListComponent implements OnInit {
  public modalRef: BsModalRef;
  lessons$ : Observable<Lesson[]>;

  constructor(private lessonService: LessonService,private modalService: BsModalService) { }

  ngOnInit(): void {
    this.lessonService.getLessons();
    this.lessons$ = this.lessonService.lessons$;
  }

  deleteDialog(id: number){
    this.modalRef = this.modalService.show(LessonDeleteComponent);
    this.modalRef.content.id = id;
    this.modalRef.content.navigate = false;
  }

}
