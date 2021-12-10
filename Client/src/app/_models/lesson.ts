import { Word } from "./word";

export interface Lesson {
    id: number;
    name: string;
    level: string;
    words: Word[];
}