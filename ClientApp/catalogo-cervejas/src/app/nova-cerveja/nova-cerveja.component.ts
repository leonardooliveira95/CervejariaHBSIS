import { Component, OnInit, Input } from '@angular/core';
import { CervejaService } from '../cerveja.service';
import { IngredienteService } from '../ingrediente.service';
import { Cerveja } from '../models/cerveja';
import { Ingrediente } from '../models/ingrediente';
import { PnotifyService } from '../pnotify.service';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-nova-cerveja',
    templateUrl: './nova-cerveja.component.html',
    styleUrls: ['./nova-cerveja.component.scss']
})
export class NovaCervejaComponent implements OnInit {

    cerveja: Cerveja = new Cerveja();
    ingredientes: Ingrediente[];
    ingredientesSelecionados: Ingrediente[] = [];
    ingredienteSelecionado: string;
    nomeCerveja: string;
    pnotify = undefined;

    constructor(private cervejaServico: CervejaService,
        private ingredienteServico: IngredienteService,
        pnotifyService: PnotifyService,
        private router: Router,
        private route: ActivatedRoute) {

        this.pnotify = pnotifyService.getPNotify();

    }

    ngOnInit() {
        this.carregarIngredientes();

        const id = +this.route.snapshot.paramMap.get('id');

        if (id !== undefined && id !== null && id > 0) {
            this.cervejaServico.buscar(id).subscribe(x => {

                this.cerveja = x;
                this.nomeCerveja = x.nome;
                this.ingredientesSelecionados = x.ingredientes;

            });
        }
    }

    carregarIngredientes(): void {
        this.ingredienteServico.buscarTodos().subscribe(x => {
            this.ingredientes = x;
        });
    }

    onSubmit(): void {

        if (this.ingredientesSelecionados.length === 0) {
            this.pnotify.alert("Escolha os ingredientes da cerveja");
            return;
        }

        this.cerveja.ingredientes = this.ingredientesSelecionados;

        this.cervejaServico.gravarCerveja(this.cerveja).subscribe(x => {

            this.pnotify.success("Cerveja cadastrada");
            this.router.navigate(["/cervejas"]);

        });
    }

    adicionarIngrediente(): void {

        var ingrediente: Ingrediente;
        ingrediente = this.ingredientes.find(x => x.id === parseInt(this.ingredienteSelecionado));

        if (ingrediente === undefined || ingrediente === null) {
            this.pnotify.alert("Escolha um ingrediente");
            return;
        }

        if (this.ingredientesSelecionados.find(x => x.id === ingrediente.id)) {
            this.pnotify.alert("O ingrediente selecionado já foi incluído");
            return;
        }

        this.ingredientesSelecionados.push(ingrediente);
    }

    removerIngrediente(ingrediente: Ingrediente): void{

        this.ingredientesSelecionados.splice(this.ingredientesSelecionados.indexOf(this.ingredientesSelecionados.find(x => x.id == ingrediente.id)), 1);

    }
}
