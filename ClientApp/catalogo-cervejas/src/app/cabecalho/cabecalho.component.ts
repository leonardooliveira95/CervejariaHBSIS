import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'app-cabecalho',
    templateUrl: './cabecalho.component.html',
    styleUrls: ['./cabecalho.component.scss']
})
export class CabecalhoComponent implements OnInit {

    @Input()
    titulo: string;
    @Input()
    iconeTitulo: string;
    @Input()
    linkBotao: string;
    @Input()
    iconeBotao: string;
    @Input()
    textoBotao: string;

    constructor() { }

    ngOnInit() {
    }

}
