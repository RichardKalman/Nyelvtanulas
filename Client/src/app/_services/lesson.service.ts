import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Lesson } from '../_models/lesson';
import { UpdateLesson } from '../_models/updateModels/updateLesson';
import { UserToAddLesson } from '../_models/userToAddLesson';
import { AddLesson } from '../_models/_addModels/addLesson';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  private baseUrl = environment.apiUrl;
  private fullUrl = this.baseUrl + 'Lesson/';
  
  private lessons = new BehaviorSubject<Lesson[]>([]);
  public lessons$ = this.lessons.asObservable();

  constructor(private http: HttpClient,private router: Router) { 
    this.getLessons();
  }

  getLessonByUser(userid:number ){    
    return this.http.get<Lesson[]>(this.fullUrl+"user/"+userid).toPromise()
  }

  getLessons(){
    this.http.get<Lesson[]>(this.fullUrl).pipe(
      map(lessons => {
        this.lessons.next(lessons);
      })
    ).toPromise(); 
  }

  addLesson(lesson: AddLesson){
    return this.http.post(this.fullUrl, lesson).pipe(
      map((l: Lesson) => {
        if (l) {
          this.router.navigateByUrl("lessons");
        }
      })
    ).toPromise();
  }

  getLessonById(id: number){
    const lesson = this.lessons.getValue().find(x => x.id === id);
    if (lesson !== undefined) return of(lesson);
    return this.http.get<Lesson>(this.fullUrl + id);
  }

  updateLesson(lesson:UpdateLesson){
    return this.http.put(this.fullUrl,lesson).pipe(
      map(() => {
        return true;
      })).toPromise()
  }

  deleteLesson(id: number){
    this.http.delete(this.fullUrl+id).subscribe({
      next: data => {
        const prev = this.lessons.getValue().filter( t => t.id !== id);
        this.lessons.next([...prev])
        
      },
      error: error => {
          console.error('There was an error!', error);
      }
    });
  }

  getNotExistUserByLessonId(id:number){
    return this.http.get<UserToAddLesson[]>(this.fullUrl + "availableusers/" + id)
  }

  addUserToLesson(userId: number, lessonId: number){
    this.http.post(this.fullUrl+"AddUserIdtoLessonId/"+userId+"/"+lessonId,null).pipe(
      map((l: Lesson) => {
        if (l) {
          const lessons = this.lessons.getValue();
          let prev = lessons.find( t => t.id === lessonId);
          prev = l;
          this.lessons.next([...lessons])
        }
      })
    ).toPromise();
  }
}
