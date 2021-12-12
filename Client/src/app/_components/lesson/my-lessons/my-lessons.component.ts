import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lesson } from 'src/app/_models/lesson';
import { Word } from 'src/app/_models/word';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-my-lessons',
  templateUrl: './my-lessons.component.html',
  styleUrls: ['./my-lessons.component.scss']
})
export class MyLessonsComponent implements OnInit {

  userId: number;
  lessons: Lesson[] = [];

  constructor(private route: ActivatedRoute, private lessonService: LessonService) { }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('userId'));
    this.loadData();
  }

  async loadData(){
    this.lessons = await this.lessonService.getLessonByUser(this.userId)
  }

  getWordsLenght(words: Word[]){
    return words.length;
  }

}
