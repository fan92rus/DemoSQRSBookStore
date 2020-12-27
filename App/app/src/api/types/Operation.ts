export interface Operation<T> {
    success: boolean;
    errors: string[];
    value: T;
}
export interface SimpleOperation {
    success: boolean;
    errors: string[];
}