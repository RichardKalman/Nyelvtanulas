import { Lesson } from "./lesson";
import { Member } from "./member";

export interface LessonResult {
  
    Id: number;
    lessonName: string;
    correctWord: number;
    notCorrectWord: number
    Users: Member[];
    Lessons: Lesson[]
}