import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Member } from '../_models/member';
import { catchError, map, tap } from 'rxjs/operators';
import { BehaviorSubject, observable, Observable, of, ReplaySubject, Subject, throwError } from 'rxjs';
import { Word } from '../_models/word';
import { AddWord } from '../_models/_addModels/addWord';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class WordsService {
  baseUrl = environment.apiUrl;
  
  private words = new BehaviorSubject<Word[]>([]);
  public words$ = this.words.asObservable();

  constructor(private http: HttpClient,private toastr: ToastrService) { 
    
  }

  getWords(){
    this.http.get<Word[]>(this.baseUrl + 'word').pipe(
      map(wordss => {
        this.words.next(wordss);
      })
    ).toPromise(); 
  }

  deleteWord(id: Number){
      this.http.delete(this.baseUrl+'word/'+id).subscribe({
        next: data => {
          const prev = this.words.getValue().filter( t => t.id !== id);
          this.words.next([...prev])
          this.toastr.success("Sikeres törlés!");
        }
      });
  }

  addWord(word: AddWord){
    return this.http.post(this.baseUrl + 'word', word).pipe(
      map((word: Word) => {
        if (word) {
          const prev = this.words.getValue();
          this.words.next([...prev , word])
          this.toastr.success("Sikeres hozzáadás!");
        }
      })
    ).toPromise();
  }

  updateWord(word: Word){
      this.http.put(this.baseUrl + 'word', word).pipe(
        map((response: any) => {          
          
          const prevWord = this.words.getValue().find( t => t.id == word.id);
          prevWord.englishWord = word.englishWord;
          prevWord.hungaryWord = word.hungaryWord; 
          this.toastr.success("Sikeres módosítás!");         
        })
      ).toPromise();
  }
}
