import { Injectable } from '@angular/core';
import {Produto} from "./produto";
import {Observable, of} from "rxjs";
import {MensagemService} from "../mensagem/mensagem.service";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, tap} from "rxjs/operators";

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
    return this.http.get<Produto[]>(this.apiUrl)
  }

  getProduto(id: number): Observable<Produto> {
    return this.http.get<Produto>(this.apiUrl+`/${id}`);
  }

  private log(mensagem: string) {
    this.serviceMensagem.add(`ProdutoService: ${mensagem}`);
  }



}
