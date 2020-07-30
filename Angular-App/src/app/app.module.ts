import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, NgModel, NgControl } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxCurrencyModule } from 'ngx-currency';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddProdutoComponent } from './Produtos/add-produto/add-produto.component';
import { ProdutosListComponent } from './Produtos/produtos-list/produtos-list.component';
import { TipoprodutosComponent } from './Produtos/tipoprodutos/tipoprodutos.component';

import { registerLocaleData, CommonModule } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    AddProdutoComponent,
    ProdutosListComponent,
    TipoprodutosComponent
  ],
  imports: [
    CommonModule, 
    BrowserModule,
    AppRoutingModule,
    FormsModule,    
    HttpClientModule,
    NgxCurrencyModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressAnimation: 'increasing',
      progressBar: true,
      closeButton: true
    })
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'pt-BR' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
