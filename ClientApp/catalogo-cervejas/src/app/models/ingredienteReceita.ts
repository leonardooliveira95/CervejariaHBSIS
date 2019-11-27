import { Ingrediente } from './ingrediente';
import { Receita } from './receita';

export class IngredienteReceita{
    
    ingrediente: Ingrediente;
    quantidade: number;
    unidadeMedida: string;
    quantidadeNecessariaDia: number;

    constructor(){
        this.ingrediente = new Ingrediente();
    }
}