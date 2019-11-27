import { Component, OnInit } from '@angular/core';

import { CervejaService } from '../cerveja.service';
import { PnotifyService } from '../pnotify.service';
import { Cerveja } from '../models/cerveja';

@Component({
    selector: 'app-cerveja',
    templateUrl: './cerveja.component.html',
    styleUrls: ['./cerveja.component.scss']
})
export class CervejaComponent implements OnInit {

    cervejas: Cerveja[];
    pnotify = undefined;

    constructor(private cervejaServico: CervejaService,
                pnotifyService: PnotifyService) { 
                    this.pnotify = pnotifyService.getPNotify();
    }

    ngOnInit() {
        this.buscarTodos();
    }


    buscarTodos(): void {
        this.cervejaServico.buscarTodos().subscribe(x => this.cervejas = x);
    }

    removerCerveja(id: number): void {

        let con = confirm("Tem certeza que deseja remover a cerveja selecionada?");

        if (con) {
            this.cervejaServico.remover(id).subscribe(x => {
                this.pnotify.success("Cerveja removida");
                this.cervejas.splice(this.cervejas.indexOf(this.cervejas.find(x => x.id == id)), 1);
            });
        }

    }

}
