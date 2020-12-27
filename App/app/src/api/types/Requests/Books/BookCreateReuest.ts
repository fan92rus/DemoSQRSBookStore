export class BookCreateRequst {
    constructor(
        public title: string,
        public price: number,
        public images: number[],
        public author: string,
    ) { }
}
