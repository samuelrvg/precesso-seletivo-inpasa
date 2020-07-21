import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ProdutoService} from "../produto.service";
import {Produto} from "../produto";
import { Location } from '@angular/common';

@Component({
  selector: 'app-produto-detalhes',
  templateUrl: './produto-detalhes.component.html',
  styleUrls: ['./produto-detalhes.component.css']
})
export class ProdutoDetalhesComponent implements OnInit {

  produto: Produto;

  constructor(
    private route: ActivatedRoute,
    private produtoService: ProdutoService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getProduto();
  }

  getProduto(): void {
    //O operador JavaScript (+) converte a sequência em um número
    const id = +this.route.snapshot.paramMap.get('id');
    this.produtoService.getProduto(id)
      .subscribe(produto => this.produto = produto);
  }

  goBack(): void {
    this.location.back();
  }

}
