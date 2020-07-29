import { TipoprodutosComponent } from './Produtos/tipoprodutos/tipoprodutos.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProdutosListComponent } from './Produtos/produtos-list/produtos-list.component';
import {AddProdutoComponent} from './Produtos/add-produto/add-produto.component';



const routes: Routes = [
  { path: '', redirectTo: 'produtos', pathMatch: 'full' },
  { path: 'produtos', component: ProdutosListComponent },
  { path: 'produtos/add', component: AddProdutoComponent },
  { path: '**', component: ProdutosListComponent },
  { path: 'tipoprodutos', component: TipoprodutosComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
