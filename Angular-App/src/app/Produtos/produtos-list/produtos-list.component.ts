import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/services/produto.service';
import { RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Produto } from '../produto';
import { TipoProduto } from '../tipoProduto';

@Component({
  selector: 'app-produtos-list',
  templateUrl: './produtos-list.component.html',
  styleUrls: ['./produtos-list.component.css']
})
export class ProdutosListComponent implements OnInit {

  produtos: Produto[];
  tipoProduto: TipoProduto[];
  tipoP: number;

  constructor(
    private produtoService: ProdutoService,
    private toastr: ToastrService,
    ) {}

  ngOnInit() {
    this.buscarProdutos();
    this.toastrPro();
    this.getTipoProduto();
  }

  // Configuração de Notificação.
  toastrPro() {
    if (sessionStorage.getItem('sucesso')) {
      this.toastr.success(sessionStorage.getItem('sucesso'));
      sessionStorage.clear();
    }

    if (sessionStorage.getItem('erro')) {
      this.toastr.error(sessionStorage.getItem('erro'));
      sessionStorage.clear();
    }
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

  // Busca os produtos no Banco.
  buscarProdutos(): void {
    this.produtoService.getAll()
      .subscribe(
        (res: Produto[]) => {
          if (res) { this.produtos = res; }
          },
        (err) => {console.log('err', err); }
        );
  }
  // Atualiza o produto
  updateProduto(produto: Produto, tipoP: number ) {
    produto.tipoProdutoId = tipoP;
    this.produtoService.update(produto.produtoId, produto)
      .subscribe(
        res => {
          sessionStorage.setItem('sucesso', 'Produto alterado com sucesso.');
          location.href = 'produtos';
        },
        error => {
          console.log(error);
          sessionStorage.setItem('erro', 'Produto não existe!');
          location.href = 'produtos';
        });
  }
  // Deleta o Produto.
  deleteProduto(id) {
    this.produtoService.delete(id)
      .subscribe(
        response => {
          sessionStorage.setItem('sucesso', 'Produto removido com sucesso.');
          location.href = 'produtos';
        },
        error => {
          console.log(error);
          sessionStorage.setItem('erro', 'Produto não existe!');
          location.href = 'produtos';
        });
  }

}
