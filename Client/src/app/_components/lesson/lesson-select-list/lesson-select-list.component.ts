import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Word } from 'src/app/_models/word';

@Component({
  selector: 'app-lesson-select-list',
  templateUrl: './lesson-select-list.component.html',
  styleUrls: ['./lesson-select-list.component.scss']
})
export class LessonSelectListComponent implements OnInit {

  @Input()
  ids: number[] = [];

  @Input()
  words$: Observable<Word[]>

  constructor() { }

  ngOnInit(): void {
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

}
