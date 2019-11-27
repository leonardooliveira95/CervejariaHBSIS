import { Cerveja } from './cerveja';
import { Ingrediente } from './ingrediente';
import { IngredienteReceita } from './ingredienteReceita';

export class Receita{
    id: number;
    garrafa: string;
    cerveja: Cerveja;
    ingredientes: IngredienteReceita[];

    constructor(){
        this.cerveja = new Cerveja();
    }
}