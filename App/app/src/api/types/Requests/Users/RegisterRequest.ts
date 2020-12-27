export enum Role {
    User,
    Manager
}

export class UserRegisterRequest {
    constructor(
        public userName: string,
        public password: string,
        public email: string,
        public balance: number,
        public role: Role,
    ) {

    }
}