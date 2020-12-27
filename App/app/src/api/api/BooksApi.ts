import axios, { AxiosInstance } from "axios";
import { Operation, SimpleOperation } from "../types/Operation";
import { BookViewModel } from "../types/Book";
import { BookCreateRequst } from "../types/Requests/Books/BookCreateReuest";
import { BookEditRequest } from "../types/Requests/Books/BookEditRequest";
import { BookGetRequest } from "../types/Requests/Books/BookGetRequest";

export class BooksApi {
    constructor(axios: AxiosInstance) {
    }

    public async GetMany(model: BookGetRequest): Promise<BookViewModel[]> {
        return (await axios.post<Operation<BookViewModel[]>>("/api​/Book​/GetAll", model)).data.value;
    }

    public async Get(id: number): Promise<BookViewModel> {
        return (await axios.get<Operation<BookViewModel>>(`/api​/Book​/Get/id=${id}`)).data.value;
    }

    public async Add(model: BookCreateRequst): Promise<number> {
        return (await axios.post<Operation<number>>("/api/Book/Add", model)).data.value;
    }

    public async Edit(model: BookEditRequest) {
        return (await axios.post<SimpleOperation>("/api/Book/Edit", model));
    }

    public async Delete(id: number) {
        return (await axios.delete<SimpleOperation>(`/api/Book/Delete/id=${id}`));
    }
}