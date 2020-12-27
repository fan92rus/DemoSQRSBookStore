import { Image } from "./Image";

export interface Book {
    id:     number;
    title:  string;
    price:  number;
    images: Image[];
    author: string;
}
