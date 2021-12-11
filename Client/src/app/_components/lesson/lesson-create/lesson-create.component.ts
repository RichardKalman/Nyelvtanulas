import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Word } from 'src/app/_models/word';
import { AddLesson } from 'src/app/_models/_addModels/addLesson';
import { LessonService } from 'src/app/_services/lesson.service';
import { WordsService } from 'src/app/_services/words.service';

@Component({
  selector: 'app-lesson-create',
  templateUrl: './lesson-create.component.html',
  styleUrls: ['./lesson-create.component.scss']
})
export class LessonCreateComponent implements OnInit {

  addLessonForm: FormGroup;
  validationErrors: string[] = [];

  words$: Observable<Word[]>;
  ids: number[] = [];

  constructor(private lessonService: LessonService,private wordService: WordsService,private fb: FormBuilder) { }

  ngOnInit(): void {
    this.words$ = this.wordService.words$;   
    this.wordService.getWords();
    this.intitializeForm();
  }

  selectRow(id: number){
    if(this.isSelected(id)){
      this.ids = this.ids.filter(ids => ids !== id);
    }
    else{
      this.ids.push(id);
    }
  }

  isSelected(id: number): boolean {
    return this.ids.includes(id);
  }

  intitializeForm() {
    this.addLessonForm = this.fb.group({
      name: ['asdsa', Validators.required],
      level: ['B1', Validators.required]
    });
  }


  addLesson(){
    let lesson = (this.addLessonForm.value as AddLesson)
    lesson.wordIds = this.ids;
    this.lessonService.addLesson(lesson);
  }


}
