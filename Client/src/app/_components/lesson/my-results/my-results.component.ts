import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LessonResult } from 'src/app/_models/lessonresult';
import { LessonResultService } from 'src/app/_services/lesson-result.service';

@Component({
  selector: 'app-my-results',
  templateUrl: './my-results.component.html',
  styleUrls: ['./my-results.component.scss']
})
export class MyResultsComponent implements OnInit {
  userId: number;
  lessonResult: LessonResult[] = [];

  constructor(private route: ActivatedRoute, private lessonResultService: LessonResultService) { }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('userId'));
    this.loadData();
  }

  async loadData(){
    this.lessonResult = await this.lessonResultService.getLessonByUserId(this.userId);
  }

}
