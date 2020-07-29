import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import {Produto} from '../Produtos/produto';
import { TipoProduto } from '../Produtos/tipoProduto';

// Rotas fornecidas pela WebApi
const BaseUrlProdutos = 'http://localhost:59163/api/produtos';
const BaseUrlTipo = 'http://localhost:59163/api/tipoprodutos';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService { constructor(private http: HttpClient) { }



  getAll(): Observable<Produto[]> {
    return this.http.get<Produto[]>(BaseUrlProdutos);
  }

  getTipoProduto(): Observable<TipoProduto[]> {
    return this.http.get<TipoProduto[]>(BaseUrlTipo);
  }

  get(id): Observable<Produto> {
    return this.http.get<Produto>(`${BaseUrlProdutos}/${id}`);
  }

  create(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(BaseUrlProdutos, produto);
  }

  update(id: number, produto: Produto): Observable<Produto> {
    return this.http.put<Produto>(`${BaseUrlProdutos}/${id}`, produto);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${BaseUrlProdutos}/${id}`);
  }}
