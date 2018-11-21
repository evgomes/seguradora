import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { RespostaDadosApi } from '../models/resposta-dados-api';
import { Seguro } from '../models/seguro';
import { map } from 'rxjs/operators';
import { TipoSeguro } from '../models/tipo-seguro';

@Injectable()
export class SegurosService {

  constructor(private http: Http) { }

  getSeguros(codigoTipoSeguro: number): Observable<RespostaDadosApi<Seguro[]>> {
    return this.http.get(`/api/seguros?tipoSeguro=${codigoTipoSeguro}`).pipe(map(res => res.json()));
  }

  getTiposSeguros() : Observable<RespostaDadosApi<TipoSeguro[]>> {
    return this.http.get(`/api/seguros/tipos`).pipe(map(res => res.json()));
  }
}
