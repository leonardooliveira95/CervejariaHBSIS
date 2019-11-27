import { Component, OnInit, Input } from '@angular/core';
import { CervejaService } from '../cerveja.service';
import { IngredienteService } from '../ingrediente.service';
import { PnotifyService } from '../pnotify.service';
import { Router, ActivatedRoute } from "@angular/router";

import { Cerveja } from '../models/cerveja';
import { Ingrediente } from '../models/ingrediente';
import { Receita } from '../models/receita';
import { IngredienteReceita } from '../models/ingredienteReceita';
import { ReceitaService } from '../receita.service';

@Component({
    selector: 'app-nova-receita',
    templateUrl: './nova-receita.component.html',
    styleUrls: ['./nova-receita.component.scss']
})
export class NovaReceitaComponent implements OnInit {

    cervejas: Cerveja[];
    ingredientes: Ingrediente[];
    ingredientesSelecionados: IngredienteReceita[] = [];
    ingredienteSelecionado: string;

    @Input()
    receita: Receita = new Receita();

    pnotify = undefined;

    constructor(private cervejaService: CervejaService,
        private ingredienteService: IngredienteService,
        private receitaService: ReceitaService,
        pnotifyService: PnotifyService,
        private router: Router, ) {

        this.pnotify = pnotifyService.getPNotify();

    }

    ngOnInit() {
        this.carregarCervejas();
        this.carregarIngredientes();
    }

    carregarCervejas(): void {
        this.cervejaService.buscarTodos().subscribe(x => {
            this.cervejas = x;
        });
    }

    carregarIngredientes(): void {
        this.ingredienteService.buscarTodos().subscribe(x => {
            this.ingredientes = x;
        });
    }

    onChangeCerveja(): void {

        let ings: Ingrediente[] = this.cervejas.find(x => x.id === +this.receita.cerveja.id).ingredientes;

        this.ingredientesSelecionados = ings.map(x => {

            let ingSelec: IngredienteReceita = new IngredienteReceita();

            ingSelec.ingrediente = x;
            ingSelec.quantidade = 0;
            ingSelec.unidadeMedida = "";

            return ingSelec;

        });
    }

    adicionarIngrediente(): void {

        let ingrediente: Ingrediente;
        ingrediente = this.ingredientes.find(x => x.id === parseInt(this.ingredienteSelecionado));

        if (ingrediente === undefined || ingrediente === null) {
            this.pnotify.alert("Escolha um ingrediente");
            return;
        }

        if (this.ingredientesSelecionados.find(x => x.ingrediente.id === ingrediente.id)) {
            this.pnotify.alert("O ingrediente selecionado já foi incluído");
            return;
        }

        let ing: IngredienteReceita = new IngredienteReceita();
        ing.ingrediente = ingrediente;

        this.ingredientesSelecionados.push(ing);
    }

    removerIngrediente(ingrediente: Ingrediente): void {

        if (confirm("Tem certeza que deseja remover o ingrediente selecionado?")) {
            this.ingredientesSelecionados.splice(this.ingredientesSelecionados.indexOf(this.ingredientesSelecionados.find(x => x.ingrediente.id == ingrediente.id)), 1);
        }
    }

    gravarReceita(): void {

        if (this.receita.garrafa === undefined || this.receita.garrafa === null || this.receita.garrafa.trim() === "") {
            this.pnotify.alert("Escolha a garrafa");
            return;
        }

        if (this.receita.cerveja === undefined || this.receita.cerveja === null || +this.receita.cerveja.id === 0) {
            this.pnotify.alert("Escolha a cerveja");
            return;
        }

        if (this.ingredientesSelecionados === undefined || this.ingredientesSelecionados === null || this.ingredientesSelecionados.length === 0) {
            this.pnotify.alert("Escolha os ingredientes da receita");
            return;
        }

        for(var i in this.ingredientesSelecionados){
            
            let x: IngredienteReceita;
            x = this.ingredientesSelecionados[i];

            if (+x.quantidade === 0) {
                this.pnotify.alert("Preencha a quantidade do ingrediente " + x.ingrediente.nome);
                return;
            }

            if (x.unidadeMedida === undefined || x.unidadeMedida === null || x.unidadeMedida === "") {
                this.pnotify.alert("Preencha a unidade de medida do ingrediente " + x.ingrediente.nome);
                return;
            }


        }

        this.receita.id = 0;
        this.receita.cerveja.id = +this.receita.cerveja.id;
        this.receita.ingredientes = this.ingredientesSelecionados;

        this.receitaService.gravar(this.receita).subscribe(x => {
            this.pnotify.success("Receita gravada");
            this.router.navigate(["/receitas"]);
        });
    }

}
