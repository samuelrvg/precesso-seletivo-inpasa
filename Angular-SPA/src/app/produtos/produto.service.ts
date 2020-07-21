import { Injectable } from '@angular/core';
import {Produto} from "./produto";
import {PRODUTOS} from "./mock-produtos";
import {Observable, of} from "rxjs";
import {MensagemService} from "../mensagem/mensagem.service";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private apiUrl = 'http://localhost:59163/api/produtos';

  constructor(
    private serviceMensagem: MensagemService,
    private http: HttpClient
  ) { }

  getProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.apiUrl);
  }

  getProduto(id: number): Observable<Produto> {
    this.log(`Produto encontrado: ${id}`);
    return of(PRODUTOS.find(produto => produto.produtoId === id));
  }

  private log(mensagem: string) {
    this.serviceMensagem.add(`ProdutoService: ${mensagem}`);
  }

}
