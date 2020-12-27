import axios, { AxiosInstance } from "axios";
import { Operation, SimpleOperation } from "../types/Operation";
import { Image } from "../types/Image";

export class BooksApi {
    constructor(axios: AxiosInstance) {
    }

    public async GetMany(skip: number, take: number): Promise<Image[]> {
        return (await axios.post<Operation<Image[]>>(`/api/Images/GetMany/?take=${take}&skip=${skip}`)).data.value;
    }

    public async Get(id: number): Promise<Image> {
        return (await axios.get<Operation<Image>>(`/api​/Images/Get/id=${id}`)).data.value;
    }
    
    public async GetByIds(Ids: number[]): Promise<Image> {
        return (await axios.post<Operation<Image>>(`​/api​/Images​/GetByIds`, Ids)).data.value;
    }

    public async Add(model: Image): Promise<number> {
        return (await axios.post<Operation<number>>("/api/Images/Add", model)).data.value;
    }

    public async Edit(model: Image) {
        return (await axios.patch<SimpleOperation>("/api/Images/Edit", model));
    }

    public async Delete(id: number) {
        return (await axios.delete<SimpleOperation>(`/api/Images/Delete/id=${id}`));
    }
}