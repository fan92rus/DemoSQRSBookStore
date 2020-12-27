import { BookFilter } from "../../Filters/BookFilter";

export class BookGetRequest {
    constructor(
        public take: number,
        public skip: number,
        public bookFilter: BookFilter,
    ) {

    }
}

