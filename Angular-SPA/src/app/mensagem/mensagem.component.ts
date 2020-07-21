import { Component, OnInit } from '@angular/core';
import {MensagemService} from "./mensagem.service";

@Component({
  selector: 'app-mensagem',
  templateUrl: './mensagem.component.html',
  styleUrls: ['./mensagem.component.css']
})
export class MensagemComponent implements OnInit {

  constructor(public serviceMensagem: MensagemService) { }

  ngOnInit() {
  }

}
