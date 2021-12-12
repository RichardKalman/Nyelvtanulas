import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { AddWord } from 'src/app/_models/_addModels/addWord';
import { WordsService } from 'src/app/_services/words.service';

@Component({
  selector: 'app-add-word',
  templateUrl: './add-word.component.html',
  styleUrls: ['./add-word.component.scss']
})
export class AddWordComponent implements OnInit {

  public onClose: Subject<boolean>;
  public deleteText: string;

  addWordForm: FormGroup;
  validationErrors: string[] = [];

  constructor(public _bsModalRef: BsModalRef, private wordServices: WordsService , private fb: FormBuilder) { }

  intitializeForm() {
    this.addWordForm = this.fb.group({
      englishWord: ['', Validators.required],
      hungaryWord: ['', Validators.required]
    });
  }


  public ngOnInit(): void {
    this.intitializeForm();
    this.onClose = new Subject();
  }

  public onCancel(): void {
    this._bsModalRef.hide();
  }

  public addWord(): void{
    this.wordServices.addWord((this.addWordForm.value as AddWord))
    this._bsModalRef.hide();
  }

}
