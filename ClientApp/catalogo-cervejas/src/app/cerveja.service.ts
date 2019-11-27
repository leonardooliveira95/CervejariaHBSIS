import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { Cerveja } from './models/cerveja';
import { Constantes } from './models/constantes';

@Injectable({
  providedIn: 'root'
})
export class CervejaService {

    private cervejaUrl = Constantes.caminhoServidor + '/cerveja';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) {

    }

    remover(id: number): Observable<string>{
        return this.http.delete<string>(this.cervejaUrl + "/" + id);
    }

    buscar(id: number): Observable<Cerveja> {
        return this.http.get<Cerveja>(this.cervejaUrl + "/" + id);
    }

    buscarTodos(): Observable<Cerveja[]> {
        return this.http.get<Cerveja[]>(this.cervejaUrl);
    }

    gravarCerveja(cerveja: Cerveja): Observable<Cerveja> {
        return this.http.post<Cerveja>(this.cervejaUrl, cerveja, this.httpOptions);
    }
}
