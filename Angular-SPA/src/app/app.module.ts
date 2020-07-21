import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// Utilização do ngModel.
import { FormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Declarar Component
import { ProdutosComponent } from './produtos/produtos.component';
import { MensagemComponent } from './mensagem/mensagem.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProdutoDetalhesComponent } from './produtos/produto-detalhes/produto-detalhes.component';
import {HttpClientModule} from "@angular/common/http";

@NgModule({
   declarations: [
      AppComponent,
      ProdutosComponent,
      MensagemComponent,
      DashboardComponent,
      ProdutoDetalhesComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule

   ],
   providers: [],
   bootstrap: [
      AppComponent,
      ProdutosComponent,
      MensagemComponent,
      DashboardComponent,
      ProdutoDetalhesComponent
   ]
})
export class AppModule { }
