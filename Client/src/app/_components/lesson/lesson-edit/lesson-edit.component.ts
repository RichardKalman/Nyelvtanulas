import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Lesson } from 'src/app/_models/lesson';
import { UpdateLesson } from 'src/app/_models/updateModels/updateLesson';
import { Word } from 'src/app/_models/word';
import { AddLesson } from 'src/app/_models/_addModels/addLesson';
import { AddWord } from 'src/app/_models/_addModels/addWord';
import { LessonService } from 'src/app/_services/lesson.service';
import { WordsService } from 'src/app/_services/words.service';

@Component({
  selector: 'app-lesson-edit',
  templateUrl: './lesson-edit.component.html',
  styleUrls: ['./lesson-edit.component.scss']
})
export class LessonEditComponent implements OnInit {

  @Input() lesson: Lesson;
  @ViewChild('editForm') editForm: NgForm;

  ids: number[] = [];

  words$: Observable<Word[]>; 

  constructor(private toastr: ToastrService,private wordService: WordsService, private lessonService: LessonService) { }

  ngOnInit(): void {
    this.words$ = this.wordService.words$;   
    this.wordService.getWords();
    this.ids = this.lesson.words.map(t => t.id);
  }

  updateLesson(){
    let wordUpdate: UpdateLesson = {
      id: this.lesson.id,
      level: this.lesson.level,
      name: this.lesson.name,
      wordIds: this.ids
    };
    
    let result = this.lessonService.updateLesson(wordUpdate);
    if(result){
      this.toastr.success("Sikeres Frissítés")
    }
  }

  selectRow(id: number){
    if(this.isSelected(id)){
      this.ids = this.ids.filter(ids => ids !== id);
    }
    else{
      this.ids.push(id);
    }
    this.updateWordListOnEntity();
  }

  updateWordListOnEntity(){
    this.words$.forEach((value: Word[]) => {
        var words = value.filter(t => this.ids.includes(t.id));
        this.lesson.words = words;
    })
  }

  isSelected(id: number): boolean {
    return this.ids.includes(id);
  }

}
