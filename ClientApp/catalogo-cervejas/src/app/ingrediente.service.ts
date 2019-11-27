import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { Ingrediente } from './models/ingrediente';
import { Constantes } from './models/constantes';

@Injectable({
    providedIn: 'root'
})
export class IngredienteService {

    private ingredienteUrl = Constantes.caminhoServidor + '/ingrediente';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) {

    }

    remover(id: number): Observable<string>{
        return this.http.delete<string>(this.ingredienteUrl + "/" + id);
    }

    buscar(id: number): Observable<Ingrediente> {
        return this.http.get<Ingrediente>(this.ingredienteUrl + "/" + id);
    }

    buscarTodos(): Observable<Ingrediente[]> {
        return this.http.get<Ingrediente[]>(this.ingredienteUrl);
    }

    gravarIngrediente(ingrediente: Ingrediente): Observable<Ingrediente> {
        return this.http.post<Ingrediente>(this.ingredienteUrl, ingrediente,this.httpOptions);
    }

}
