import { ToastrService } from 'ngx-toastr';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { TipoSeguro } from '../../models/tipo-seguro';
import { SegurosService } from '../../services/seguros.service';

@Component({
  selector: 'app-select-tipos-seguro',
  templateUrl: './select-tipos-seguro.component.html',
  styleUrls: ['./select-tipos-seguro.component.css']
})
export class SelectTiposSeguroComponent implements OnInit {
  tipos: TipoSeguro[] = [];
  @Input('desabilitado') desabilitado: boolean = false;
  @Input('exibirOpcaoSelecione') exibirOpcaoSelecione: boolean = true;
  @Input('codigoTipoSegurado') codigoTipoSegurado: number = 0;
  @Output('onSelecionarTipoSeguro') onSelecionarTipoSeguroEmitter: EventEmitter<number> = new EventEmitter();

  constructor(private segurosService: SegurosService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.popularTipos()
  }

  popularTipos() {
    this.segurosService.getTiposSeguros().subscribe(resposta => {
      this.tipos = resposta.dados;
    }, error => {
      this.toastrService.error('Ocorreu um erro ao listar os tipos de seguros: ' + error);
    });
  }

  onSelecionarTipoSeguro(codigoTipoSelecionado: number) {
    if (this.desabilitado) {
      return;
    }

    this.codigoTipoSegurado = codigoTipoSelecionado;
    this.onSelecionarTipoSeguroEmitter.emit(this.codigoTipoSegurado);
  }
}
