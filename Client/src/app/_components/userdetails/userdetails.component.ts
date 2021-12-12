import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Lesson } from 'src/app/_models/lesson';
import { LessonResult } from 'src/app/_models/lessonresult';
import { Member } from 'src/app/_models/member';
import { Word } from 'src/app/_models/word';
import { LessonResultService } from 'src/app/_services/lesson-result.service';
import { LessonService } from 'src/app/_services/lesson.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.scss']
})
export class UserdetailsComponent implements OnInit {
  member: Member ;
  lessons: Lesson[] = [];
  lessonResult: LessonResult[] = [];

  constructor(private memberService: MembersService, private lessonService: LessonService ,private route: ActivatedRoute, private router: Router,  private lessonResultService: LessonResultService,) { }

  ngOnInit(): void {
    
   this.loadData();
    
    
  }

  async loadData() {
    this.member =  await this.memberService.getMember(this.route.snapshot.paramMap.get('username'));
    this.lessons = await this.lessonService.getLessonByUser(this.member.id);
    this.lessonResult = await this.lessonResultService.getLessonByUserId(this.member.id);
  }

  getWordsLenght(words: Word[]){
    return words.length;
  }

}
