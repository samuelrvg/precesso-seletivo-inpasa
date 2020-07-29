import { ProdutoService } from 'src/app/services/produto.service';
import { Component, OnInit } from '@angular/core';
import { TipoProduto } from '../tipoProduto';

@Component({
  selector: 'app-tipoprodutos',
  templateUrl: './tipoprodutos.component.html',
  styleUrls: ['./tipoprodutos.component.css']
})
export class TipoprodutosComponent implements OnInit {
  tipoProduto: TipoProduto[];  

  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {
    this.getTipoProduto();
  }

  getTipoProduto(): void {
    this.produtoService.getTipoProduto()
    .subscribe(
      (res: TipoProduto[]) => {
        if (res) { this.tipoProduto = res; }
        },
      (err) => {console.log('err', err); }
      );
  }

}
