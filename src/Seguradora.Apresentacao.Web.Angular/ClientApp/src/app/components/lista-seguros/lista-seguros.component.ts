import { Component, OnInit } from '@angular/core';

import { Seguro } from '../../models/seguro';
import { TipoSeguro } from '../../models/tipo-seguro';
import { SegurosService } from '../../services/seguros.service';


@Component({
  selector: 'app-lista-seguros',
  templateUrl: './lista-seguros.component.html',
  styleUrls: ['./lista-seguros.component.css']
})
export class ListaSegurosComponent implements OnInit {
  seguros: Seguro[] = [];
  tipos: TipoSeguro[] = [];
  codigoTipoSeguroSelecionado: number = 0;

  constructor(private segurosService: SegurosService) { }

  ngOnInit() {
    this.popularTipos();
    this.popularSeguros();
  }

  popularTipos() {
    this.segurosService.getTiposSeguros().subscribe(resposta => {
      if (!resposta.sucesso) {
        alert(resposta.mensagem);
        return;
      }

      this.tipos = resposta.dados;
    });
  }

  popularSeguros() {
    this.segurosService.getSeguros(this.codigoTipoSeguroSelecionado).subscribe(resultado => {
      if (!resultado.sucesso) {
        alert(resultado.mensagem);
        this.seguros.splice(0);
        return;
      }

      this.seguros = resultado.dados;
    });
  }

  onSelecionarTipoSeguro(codigoSelecionado : number) {
    this.codigoTipoSeguroSelecionado = codigoSelecionado;
    this.popularSeguros();
  }
}
