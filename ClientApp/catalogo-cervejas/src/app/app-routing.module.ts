import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IngredienteComponent } from './ingrediente/ingrediente.component';
import { NovoIngredienteComponent } from './novo-ingrediente/novo-ingrediente.component';
import { CervejaComponent } from './cerveja/cerveja.component';
import { NovaCervejaComponent } from './nova-cerveja/nova-cerveja.component';
import { ReceitaComponent } from './receita/receita.component';
import { NovaReceitaComponent } from './nova-receita/nova-receita.component';

const routes: Routes = [
    { path: '', redirectTo: '/receitas', pathMatch: 'full' },
    { path: 'ingredientes', component: IngredienteComponent },
    { path: 'novoIngrediente', component: NovoIngredienteComponent },
    { path: 'editarIngrediente/:id', component: NovoIngredienteComponent },
    { path: 'cervejas', component: CervejaComponent },
    { path: 'novaCerveja', component: NovaCervejaComponent },
    { path: 'editarCerveja/:id', component: NovaCervejaComponent },
    { path: 'receitas', component: ReceitaComponent },
    { path: 'novaReceita', component: NovaReceitaComponent }
];

@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
