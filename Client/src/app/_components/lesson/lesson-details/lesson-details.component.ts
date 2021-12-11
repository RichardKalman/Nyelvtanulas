import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Lesson } from 'src/app/_models/lesson';
import { LessonService } from 'src/app/_services/lesson.service';
import { LessonDeleteComponent } from '../../dialogs/lesson-delete/lesson-delete.component';

@Component({
  selector: 'app-lesson-details',
  templateUrl: './lesson-details.component.html',
  styleUrls: ['./lesson-details.component.scss']
})
export class LessonDetailsComponent implements OnInit {

  public modalRef: BsModalRef;
  lesson: Lesson;

  constructor(private lessonService: LessonService, private route: ActivatedRoute,private modalService: BsModalService) { }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    this.lessonService.getLessonById(Number(this.route.snapshot.paramMap.get('id'))).subscribe(lesson => {
      this.lesson = lesson;
    })
  }

  delete(){
    this.modalRef = this.modalService.show(LessonDeleteComponent);
    this.modalRef.content.id = this.lesson.id;
    this.modalRef.content.navigate = true;
  }

}
