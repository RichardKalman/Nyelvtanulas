import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Word } from 'src/app/_models/word';
import { WordsService } from 'src/app/_services/words.service';

@Component({
  selector: 'app-update-word',
  templateUrl: './update-word.component.html',
  styleUrls: ['./update-word.component.scss']
})
export class UpdateWordComponent implements OnInit {

  public word: Word = {hungaryWord: "", englishWord:"", id :0};
  updateWordForm: FormGroup;
  validationErrors: string[] = [];

  constructor(public _bsModalRef: BsModalRef, private wordServices: WordsService , private fb: FormBuilder) { }

  intitializeForm() {
    this.updateWordForm = this.fb.group({
      englishWord: [this.word.englishWord, Validators.required],
      hungaryWord: [this.word.hungaryWord, Validators.required]
    });
  }


  public ngOnInit(): void {
    
    this.intitializeForm();
  }

  public onCancel(): void {
    this._bsModalRef.hide();
  }

  public UpdateWord(): void{
    this.word.englishWord = this.updateWordForm.controls["englishWord"].value;
    this.word.hungaryWord = this.updateWordForm.controls["hungaryWord"].value;

    this.wordServices.updateWord(this.word)
  
  }

}
