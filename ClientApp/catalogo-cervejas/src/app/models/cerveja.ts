import { Ingrediente } from './ingrediente';

export class Cerveja {
    id: number;
    nome: string;
    marca: string;
    ingredientes: Ingrediente[];
    familia: string;
    estilo: string;
    abv: string;
    ibu: string;
}