import { ProdutoService } from 'src/app/services/produto.service';
import { Component, OnInit } from '@angular/core';
import { TipoProduto } from '../tipoProduto';
import { Produto } from '../produto';

@Component({
  selector: 'app-tipoprodutos',
  templateUrl: './tipoprodutos.component.html',
  styleUrls: ['./tipoprodutos.component.css']
})
export class TipoprodutosComponent implements OnInit {
  
  tipoEmUso: boolean;
  produtos: Produto[];
  tipoProduto: TipoProduto[];
  tipoProdutoSave = {
    tipoNome: ''
  };  

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

  saveTipoProduto(tipoProdutoSave): void {   
    this.produtoService.createTipoProduto(tipoProdutoSave)
      .subscribe(
        (res: TipoProduto) => {
          console.log(res);          
          location.href = 'produtos/tipoprodutos';
        },
        error => {
          console.log(error);          
          location.href = 'produtos';
        });
      }
  
  remover(id): void {
    this.produtoService.deleteTipoProduto(id)
      .subscribe(
      res => {
        console.log(res);
        location.href = 'produtos/tipoprodutos';
      },
      (err: any) => 
      { 
        if (err.status == 400) {
          sessionStorage.setItem('erro', 'TipoProduto não pode ser removido em uso!');
          location.href = 'produtos';
      } 
        if (err.status == 200) {
          console.log('err', err)
          location.href = 'produtos/tipoprodutos';
      }
    });
  }

}
