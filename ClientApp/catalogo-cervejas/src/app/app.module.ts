import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { IngredienteComponent } from './ingrediente/ingrediente.component';
import { AppRoutingModule } from './app-routing.module';
import { NovoIngredienteComponent } from './novo-ingrediente/novo-ingrediente.component';

import { PnotifyService } from './pnotify.service';
import { CervejaComponent } from './cerveja/cerveja.component';
import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { LoadingComponent } from './loading/loading.component';
import { NovaCervejaComponent } from './nova-cerveja/nova-cerveja.component';
import { ReceitaComponent } from './receita/receita.component';
import { NovaReceitaComponent } from './nova-receita/nova-receita.component';

@NgModule({
    declarations: [
        AppComponent,
        IngredienteComponent,
        NovoIngredienteComponent,
        CervejaComponent,
        CabecalhoComponent,
        LoadingComponent,
        NovaCervejaComponent,
        ReceitaComponent,
        NovaReceitaComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        NgbModule,
        AppRoutingModule,
        FormsModule
    ],
    providers: [PnotifyService],
    bootstrap: [AppComponent]
})
export class AppModule { }
