import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// Utilização do ngModel.
import { FormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// Declarar Component
import { ProdutosComponent } from './produtos/produtos.component';
import { ProdutoDetalhesComponent } from './produtos/produto-detalhes/produto-detalhes.component';

@NgModule({
   declarations: [
      AppComponent,
      ProdutosComponent,
      ProdutoDetalhesComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule
      
   ],
   providers: [],
   bootstrap: [
      AppComponent,
      ProdutosComponent,
      ProdutoDetalhesComponent
   ]
})
export class AppModule { }
