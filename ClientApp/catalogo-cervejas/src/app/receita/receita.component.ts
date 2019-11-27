import { Component, OnInit, Input } from '@angular/core';

import { PnotifyService } from '../pnotify.service';
import { ReceitaService } from '../receita.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { Receita } from '../models/receita';
import { IngredienteReceita } from '../models/ingredienteReceita';

@Component({
    selector: 'app-receita',
    templateUrl: './receita.component.html',
    styleUrls: ['./receita.component.scss']
})
export class ReceitaComponent implements OnInit {

    @Input()
    quantidadeGarrafas: number;

    @Input()
    quantidadeGarrafasTodas: number;

    receitas: Receita[];
    ingredientes: IngredienteReceita[];
    ingredientesTotais: IngredienteReceita[];

    pnotify = undefined;

    constructor(private receitaService: ReceitaService,
        pnotifyService: PnotifyService,
        private modalService: NgbModal) {

        this.pnotify = pnotifyService.getPNotify();

    }

    ngOnInit() {

        this.receitaService.buscarTodos().subscribe(x => {
            this.receitas = x;
        });

    }

    abrirModalCalculo(content: any, receita: Receita): void {

        this.ingredientes = receita.ingredientes;
        this.modalService.open(content, { windowClass: 'modal-holder', centered: true, size: "lg" });
    }

    abrirModalCalculoTodas(content: any): void {
        this.modalService.open(content, { windowClass: 'modal-holder', centered: true, size: "xl" });
    }

    calcularProducaoDiariaUnica(): void {

        this.calcularProducaoDiaria(this.ingredientes, this.quantidadeGarrafas);

    }

    calcularProducaoDiariaTodas(): void {

        this.receitas.forEach(x => {

            this.calcularProducaoDiaria(x.ingredientes, this.quantidadeGarrafasTodas);

        });

        this.calcularProducaoDiariaTotal();
    }

    calcularProducaoDiaria(ingredientes: IngredienteReceita[], quantidadeGarrafas: number): void {

        ingredientes.forEach(x => {
            x.quantidadeNecessariaDia = +(x.quantidade * quantidadeGarrafas).toFixed(2);
        });

        
    }

    calcularProducaoDiariaTotal(): void{

        let res: IngredienteReceita[] = [];

        this.receitas.forEach(x => {

            x.ingredientes.forEach(y => {

                let obj = res.find(z => z.ingrediente.id === y.ingrediente.id)

                if(obj === undefined){
                    
                    let ing: IngredienteReceita = new IngredienteReceita();

                    ing.ingrediente = y.ingrediente;
                    ing.quantidade = y.quantidade;
                    ing.quantidadeNecessariaDia = y.quantidade * this.quantidadeGarrafasTodas;
                    ing.unidadeMedida = y.unidadeMedida;

                    res.push(ing);
                }
                else {
                    obj.quantidadeNecessariaDia += y.quantidade  * this.quantidadeGarrafasTodas;
                }

            });

        });

        this.ingredientesTotais = res;
    }
}
