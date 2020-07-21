import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProdutosComponent} from "./produtos/produtos.component";
import {DashboardComponent} from "./dashboard/dashboard.component";
import {ProdutoDetalhesComponent} from "./produtos/produto-detalhes/produto-detalhes.component";

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent},
  { path: 'detalhes/:id', component: ProdutoDetalhesComponent },
  { path: 'produtos', component: ProdutosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
