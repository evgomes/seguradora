import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';

import { RespostaDadosApi } from '../models/resposta-dados-api';
import { Seguro } from '../models/seguro';
import { TipoSeguro } from '../models/tipo-seguro';
import { SalvarSeguro } from './../models/salvar-seguro';

@Injectable()
export class SegurosService {

  constructor(private http: Http) { }

  getSeguros(codigoTipoSegurado: number): Observable<RespostaDadosApi<Seguro[]>> {
    return this.http.get(`/api/seguros?tipoSeguro=${codigoTipoSegurado}`).pipe(map(res => res.json()));
  }

  getTiposSeguros(): Observable<RespostaDadosApi<TipoSeguro[]>> {
    return this.http.get(`/api/seguros/tipos`).pipe(map(res => res.json()));
  }

  getSeguro(id: number): Observable<RespostaDadosApi<Seguro>> {
    return this.http.get(`/api/seguros/${id}`).pipe(map(res => res.json()));
  }

  criar(seguro: SalvarSeguro): Observable<RespostaDadosApi<Seguro>> {
    return this.http.post(`/api/seguros`, seguro).pipe(map(res => res.json()));
  }

  atualizar(id: number, seguro: SalvarSeguro): Observable<RespostaDadosApi<Seguro>> {
    return this.http.put(`/api/seguros/${id}`, seguro).pipe(map(res => res.json()));
  }

  excluir(id: number) {
    return this.http.delete(`/api/seguros/${id}`).pipe(map(res => res.json()));
  }
}
