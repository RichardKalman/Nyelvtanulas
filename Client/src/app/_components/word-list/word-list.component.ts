
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { getDate } from 'ngx-bootstrap/chronos/utils/date-getters';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { from, Observable, of } from 'rxjs';
import { FromEventTarget } from 'rxjs/internal/observable/fromEvent';
import { Word } from 'src/app/_models/word';
import { WordsService } from 'src/app/_services/words.service';
import { AddWordComponent } from '../dialogs/add-word/add-word.component';
import { DeleteDialogComponent } from '../dialogs/delete-dialog/delete-dialog.component';
import { UpdateWordComponent } from '../dialogs/update-word/update-word.component';

@Component({
  selector: 'app-word-list',
  templateUrl: './word-list.component.html',
  styleUrls: ['./word-list.component.scss']
})
export class WordListComponent implements OnInit {
  public modalRef: BsModalRef;
  private addModalRef: BsModalRef;
  private updateModalRef: BsModalRef;
  
  words$: Observable<Word[]> ;
  
  constructor(private wordService: WordsService,private modalService: BsModalService , private fb: FormBuilder) { }

  ngOnInit(): void {    
    this.words$ = this.wordService.words$;   
    this.wordService.getWords();
    
  }

  delete(id: number) {
    this.modalRef = this.modalService.show(DeleteDialogComponent);
    this.modalRef.content.deleteText = "Biztosan törlöd ezt a szót?"
    this.modalRef.content.onClose.subscribe(result => {
        if(result){
          const deleteresult = this.wordService.deleteWord(id);          
        }
    })
  }

  addDialogOpen(){
    this.addModalRef = this.modalService.show(AddWordComponent)
  }

  updateDialogOpen(word: Word){
    this.updateModalRef = this.modalService.show(UpdateWordComponent);
    this.updateModalRef.content.word = {...word};
    console.log(word)
  }

}
