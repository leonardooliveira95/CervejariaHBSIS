import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";
import { IngredienteService } from '../ingrediente.service';
import { Ingrediente } from '../models/ingrediente';
import { PnotifyService } from '../pnotify.service';

@Component({
    selector: 'app-novo-ingrediente',
    templateUrl: './novo-ingrediente.component.html',
    styleUrls: ['./novo-ingrediente.component.scss']
})
export class NovoIngredienteComponent implements OnInit {

    pnotify = undefined;
    ingrediente: Ingrediente = new Ingrediente();
    nomeIngrediente: string;

    constructor(private ingredienteServico: IngredienteService,
        pnotifyService: PnotifyService,
        private router: Router,
        private route: ActivatedRoute) {

        this.pnotify = pnotifyService.getPNotify();

    }

    ngOnInit() {
        const id = +this.route.snapshot.paramMap.get('id');

        if (id !== undefined && id !== null && id > 0) {
            this.ingredienteServico.buscar(id).subscribe(x => {

                this.ingrediente = x;
                this.nomeIngrediente = x.nome;

            });
        }
    }

    cadastrarIngrediente(): void {

        this.ingredienteServico.gravarIngrediente(this.ingrediente)
            .subscribe(ingrediente => {

                this.pnotify.success(this.ingrediente.id === undefined || this.ingrediente.id === null || this.ingrediente.id === 0 ? "Ingrediente cadastrado" : "Ingrediente atualizado");
                this.router.navigate(["/ingredientes"]);

            });

    }
}
