import { Component, OnInit, Input } from '@angular/core';
import { ProdutoService } from 'src/app/services/produto.service';
import { Produto } from '../produto';
import { TipoProduto } from '../tipoProduto';

@Component({
  selector: 'app-add-produto',
  templateUrl: './add-produto.component.html',
  styleUrls: ['./add-produto.component.css']
})
export class AddProdutoComponent implements OnInit {

  produto = {
    nome: '',
    descricao: '',
    preco: 0,
    tipoProdutoId: 0
  };

  tipoProduto: TipoProduto[]; 

  constructor(
    private produtoService: ProdutoService
    ) { }

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

  saveProduto(produto): void {   
    this.produtoService.create(produto)
      .subscribe(
        (res: Produto) => {
          console.log(res);
          sessionStorage.setItem('sucesso', 'Produto cadastrado com sucesso.');
          location.href = 'produtos';
        },
        error => {
          console.log(error);
          sessionStorage.setItem('erro', error);
          location.href = 'produtos';
        });
  }

}
