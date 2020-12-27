import { BookViewModel } from "./Book";

export interface User {
    Name: string,
    Email: string,
    Rating: number,
    Books: BookViewModel[]
}