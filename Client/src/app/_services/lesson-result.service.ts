import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LessonResult } from '../_models/lessonresult';

@Injectable({
  providedIn: 'root'
})
export class LessonResultService {
  private baseUrl = environment.apiUrl;
  private fullUrl = this.baseUrl + 'LessonResult/';

  private lessonResults = new BehaviorSubject<LessonResult[]>([]);
  public lessonResults$ = this.lessonResults.asObservable();

  constructor(private http: HttpClient,private router: Router) { }

  getLessons(){
    this.http.get<LessonResult[]>(this.fullUrl).pipe(
      map(lessons => {
        this.lessonResults.next(lessons);
      })
    ).toPromise(); 
  }

  getLessonByUserId( userid:number ){    
    return this.http.get<LessonResult[]>(this.fullUrl+"user/"+userid).toPromise()
  }

  addResult(data: any){
    this.http.post(this.fullUrl,data).pipe(
      map((l: LessonResult) => {
        if (l) {
         this.router.navigateByUrl("/users")
        }
      })
    ).toPromise()
  }
}
