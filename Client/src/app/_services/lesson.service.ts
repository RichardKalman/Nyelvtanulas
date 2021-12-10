import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Lesson } from '../_models/lesson';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  baseUrl = environment.apiUrl;
  private fullUrl = this.baseUrl + 'Lesson';
  
  private lessons = new BehaviorSubject<Lesson[]>([]);
  public lessons$ = this.lessons.asObservable();

  constructor(private http: HttpClient) { 
    
  }

  getLessons(){
    this.http.get<Lesson[]>(this.fullUrl).pipe(
      map(lessons => {
        this.lessons.next(lessons);
      })
    ).toPromise(); 
  }
}
