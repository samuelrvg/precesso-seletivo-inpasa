import { Component, OnInit } from '@angular/core';
import {Produto} from "../produtos/produto";
import {ProdutoService} from "../produtos/produto.service";
import {MensagemService} from "../mensagem/mensagem.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  produtos: Produto[] = [];

  constructor(
    private produtoService: ProdutoService,
    private mensagemService: MensagemService
  ) { }

  ngOnInit() {
    this.getProdutos();
  }

  getProdutos(): void {
    this.produtoService.getProdutos()
      .subscribe(
        (res: Produto[]) => {
            if (res) {
              this.mensagemService.clear();
              this.produtos = res.slice(0,5);
            }
        },
        (err) => {
            console.log("err", err);
        }
    );
  }

}
