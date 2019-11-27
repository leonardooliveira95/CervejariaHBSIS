import { Component, OnInit } from '@angular/core';
import { IngredienteService } from '../ingrediente.service';
import { Ingrediente } from '../models/ingrediente';
import { PnotifyService } from '../pnotify.service';

@Component({
    selector: 'app-ingrediente',
    templateUrl: './ingrediente.component.html',
    styleUrls: ['./ingrediente.component.scss']
})
export class IngredienteComponent implements OnInit {

    ingredientes: Ingrediente[];
    loading: boolean;
    pnotify = undefined;

    constructor(private ingredienteServico: IngredienteService,
        pnotifyService: PnotifyService) {
        this.pnotify = pnotifyService.getPNotify();
    }

    ngOnInit() {
        this.buscarTodos();
    }


    buscarTodos(): void {

        this.loading = true;
        this.ingredienteServico.buscarTodos().subscribe(x => {
            this.loading = false;
            this.ingredientes = x;
        });
    }

    removerIngrediente(id: number): void {

        let con = confirm("Tem certeza que deseja remover o ingrediente selecionado?");

        if (con) {
            this.ingredienteServico.remover(id).subscribe(x => {
                this.pnotify.success("Ingrediente removido");
                this.ingredientes.splice(this.ingredientes.indexOf(this.ingredientes.find(x => x.id == id)), 1);
            });
        }

    }
}
