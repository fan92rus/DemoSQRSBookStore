import axios, { AxiosInstance } from "axios";
import { Operation, SimpleOperation } from "../types/Operation";
import { LoginRequest } from "../types/Requests/Users/LoginRequest";
import { UserRegisterRequest } from "../types/Requests/Users/RegisterRequest";
import { User } from "../types/User";

export class UserApi {
    constructor(axios: AxiosInstance) {
    }
    /**
     * Авторизация
     * @param model Модель авторизации
     */
    public async Login(model: LoginRequest): Promise<boolean> {
        return await (await axios.post<boolean>("/api/User/Login", model)).data;
    }
    /**
     * Регистрация
     * @param model модель регистрации
     */
    public async Register(model: UserRegisterRequest): Promise<SimpleOperation> {
        return await (await axios.post<SimpleOperation>("/api/User/Login", model)).data;
    }
    /**
     * Получает модель авторизированого юзера
     */
    public async Get(): Promise<User> {
        return await (await axios.post<User>("/api/User/Get")).data;
    }

}