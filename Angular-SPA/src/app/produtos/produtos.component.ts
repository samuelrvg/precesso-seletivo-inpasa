import { Component, OnInit } from '@angular/core';
import { Produto } from './produto';
import { PRODUTOS } from "./mock-produtos";
import {ProdutoService} from "./produto.service";
import {MensagemService} from "../mensagem/mensagem.service";

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {


  // selectedProduto: Produto;
  produtos: Produto[];

  constructor(
    private produtoService: ProdutoService,
    private mensagemService: MensagemService ) { }

  ngOnInit() {
    this.getProdutos();
  }

  getProdutos(): void {
    this.produtoService.getProdutos()
      .subscribe(produtos => {
        this.mensagemService.clear()
        this.mensagemService.add(`Foram encontrados ${produtos.length} produtos.`)
        this.produtos = produtos
      });
  }


  // Seleciona o produto e retorna.
  /*onSelect(produto: Produto) : void {
    this.selectedProduto = produto;
    this.mensagemService.clear();
    this.mensagemService.add(`Produto selecionado ID = ${produto.produtoId}`);
  }*/

}
