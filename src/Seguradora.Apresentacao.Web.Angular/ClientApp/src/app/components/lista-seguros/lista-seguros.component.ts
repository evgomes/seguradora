import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';

import { Seguro } from '../../models/seguro';
import { SegurosService } from '../../services/seguros.service';

@Component({
  selector: 'app-lista-seguros',
  templateUrl: './lista-seguros.component.html',
  styleUrls: ['./lista-seguros.component.css']
})
export class ListaSegurosComponent implements OnInit {
  
  seguros: Seguro[] = [];
  segurosFiltrados: Seguro[] = [];
  codigoTipoSegurado: number = 0;

  constructor(private segurosService: SegurosService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.popularSeguros();
  }

  popularSeguros() {
    this.segurosService.getSeguros(this.codigoTipoSegurado).subscribe(resultado => {
      this.seguros.splice(0);

      for (let seguro of resultado.dados) {
        this.seguros.push(new Seguro(seguro));
      }

      this.segurosFiltrados = this.seguros;
    }, error => {
      this.toastrService.error('Ocorreu um erro: ' + error);
      this.seguros.splice(0);
    });
  }

  filtrarSeguros(placa: string) {
    const placaFormatada = placa.toLowerCase();
    this.segurosFiltrados = this.seguros.filter(s => s.placa.toLowerCase().startsWith(placaFormatada));
  }

  onSelecionarTipoSeguro(codigoTipoSelecionado: number) {
    this.codigoTipoSegurado = codigoTipoSelecionado;
    this.popularSeguros();
  }
}
