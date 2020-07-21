import { Component, OnInit } from '@angular/core';
import { Produto } from './produto';
import {ProdutoService} from "./produto.service";
import {MensagemService} from "../mensagem/mensagem.service";

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  produtos: Produto[];

  constructor(
    private produtoService: ProdutoService,
    private mensagemService: MensagemService
  ) { }

  ngOnInit() {
    this.getProdutos();
  }

  getProdutos(): void {
    this.produtoService.getProdutos()
      .subscribe(produtos => {
        this.mensagemService.clear();
        this.mensagemService.add(`Foram encontrados ${produtos.length} produtos.`);
        this.produtos = produtos;
        console.log(produtos);
      });
  }

}
