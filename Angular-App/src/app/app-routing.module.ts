import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProdutosListComponent } from './Produtos/produtos-list/produtos-list.component';
import {AddProdutoComponent} from './Produtos/add-produto/add-produto.component';
import { TipoprodutosComponent } from './Produtos/tipoprodutos/tipoprodutos.component';


const routes: Routes = [
  { path: '', redirectTo: 'produtos', pathMatch: 'full' },
  { path: 'produtos', component: ProdutosListComponent },
  { path: 'produtos/add', component: AddProdutoComponent },
  { path: 'produtos/tipoprodutos', component: TipoprodutosComponent},
  { path: '**', component: ProdutosListComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
