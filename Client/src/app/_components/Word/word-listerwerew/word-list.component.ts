
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Word } from 'src/app/_models/word';
import { WordsService } from 'src/app/_services/words.service';

@Component({
  selector: 'app-word-list',
  templateUrl: './word-list.component.html',
  styleUrls: ['./word-list.component.scss']
})
export class WordListComponent implements OnInit {

  words$: Observable<Word[]>;
  
  constructor(private wordService: WordsService) { }

  ngOnInit(): void {
    this.words$ = this.wordService.getWords();
    console.log(this.words$);
  }

}
