export interface response<T>{
    errors:T,
    message: string,
    sucesso: boolean,
    tRetorno: T
}