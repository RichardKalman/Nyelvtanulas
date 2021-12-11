import { Lesson } from "./lesson";

export interface Member {
    id: number;
    userName: string;
    dateOfBirth: Date;
    created: Date;
    lastActive: Date;
    email: string;
    age: number;
    gender: string;
    lessons: Lesson[];
}