import { RespostaApi } from "./resposta-api";

export interface RespostaDadosApi<T> extends RespostaApi {
    dados: T,
}