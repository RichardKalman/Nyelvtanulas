import { FormatWidth } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Word } from 'src/app/_models/word';
import { LessonResultService } from 'src/app/_services/lesson-result.service';
import { LessonService } from 'src/app/_services/lesson.service';

@Component({
  selector: 'app-do-lesson',
  templateUrl: './do-lesson.component.html',
  styleUrls: ['./do-lesson.component.scss']
})
export class DoLessonComponent implements OnInit {

  lessonId: number;
  userId: number;

  szavak: Word[] = []

  wordForm: FormGroup;

  constructor(private route: ActivatedRoute,private lessonResultService: LessonResultService, private lessonService: LessonService, private fb: FormBuilder) { }

  ngOnInit(): void {    
    this.lessonId = Number(this.route.snapshot.paramMap.get('lessonId'));
    this.userId = Number(this.route.snapshot.paramMap.get('userId'));
    this.initForm();
    this.lessonService.getLessonById(this.lessonId).subscribe(w => {
      this.szavak = [...w.words]
      this.szavak.forEach(word => {
        this.getWords().push(this.addWordToForm(word.id,word.englishWord));
      });
    });
    
  }

  getWords() : FormArray{
    return this.wordForm.get('words') as FormArray;
  }

  initForm(){
    this.wordForm = this.fb.group({
      userId: this.userId,
      lessonId: this.lessonId,
      words: this.fb.array([]),
    })
  }

  addWordToForm(id: number, english: string): FormGroup {
    return this.fb.group({
      id: id,
      englishWord: english,
      hungaryWord: ''
    })
  }

  send(){
    this.lessonResultService.addResult(this.wordForm.value)
  }

  

}
