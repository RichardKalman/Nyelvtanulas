import { Lesson } from "./lesson";
import { LessonResult } from "./lessonresult";

export interface Member {
    id: number;
    FullName: string;
    userName: string;
    dateOfBirth: Date;
    created: Date;
    lastActive: Date;
    email: string;
    age: number;
    gender: string;
    lessons: Lesson[];
    lessonsResult: LessonResult[]
}