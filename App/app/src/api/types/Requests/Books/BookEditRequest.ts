import { BookCreateRequst } from "./BookCreateReuest";
import { IEntity } from "../../Entity";
export class BookEditRequest extends BookCreateRequst implements IEntity {
    constructor(
        public id: number,
        public title: string,
        public price: number,
        public images: number[],
        public author: string,
    ) {
        super(title, price, images, author)
    }
}