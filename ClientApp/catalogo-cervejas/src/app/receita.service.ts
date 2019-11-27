import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { Receita } from './models/receita';
import { Constantes } from './models/constantes';

@Injectable({
    providedIn: 'root'
})
export class ReceitaService {

    private receitaUrl = Constantes.caminhoServidor + '/receita';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) { }

    buscarTodos(): Observable<Receita[]> {
        return this.http.get<Receita[]>(this.receitaUrl);
    }

    gravar(receita: Receita): Observable<Receita> {
        return this.http.post<Receita>(this.receitaUrl, receita, this.httpOptions);
    }
}
