import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

import { RespostaDadosApi } from '../../models/resposta-dados-api';
import { SalvarSeguro } from '../../models/salvar-seguro';
import { Seguro } from '../../models/seguro';
import { SegurosService } from '../../services/seguros.service';

@Component({
  selector: 'app-seguro-form',
  templateUrl: './seguro-form.component.html',
  styleUrls: ['./seguro-form.component.css']
})
export class SeguroFormComponent implements OnInit {
  seguro: SalvarSeguro = new SalvarSeguro();
  seguroId: number = 0;
  tipoCliente: string = 'pessoaFisica';
  subscription: Subscription;

  @ViewChild('documentoCpf') documentoCpf: ElementRef;
  @ViewChild('documentoCnpj') documentoCnpj: ElementRef;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private segurosService: SegurosService,
    private toastrService: ToastrService) {
    route.params.subscribe(p => {
      this.seguroId = +p['id'];
    });
  }

  ngOnInit() {
    if (this.seguroId > 0) {
      this.subscription = this.segurosService.getSeguro(this.seguroId).subscribe(resposta => {
        this.seguro = new SalvarSeguro(resposta.dados);

        if (this.seguro.cpfCnpj.length == 11) {
          this.tipoCliente = 'pessoaFisica';
          this.documentoCpf.nativeElement.checked = true;
          this.documentoCnpj.nativeElement.checked = false;
        } else {
          this.tipoCliente = 'pessoaJuridica';
          this.documentoCpf.nativeElement.checked = false;
          this.documentoCnpj.nativeElement.checked = true;
        }
      }, erro => {
        this.toastrService.info('Seguro não encontrado.');
        this.router.navigate(['/']);
      });
    }
  }

  submit() {
    if (this.seguro.codigoTipo == 0) {
      this.seguro.codigoTipo = 1;
    }

    this.salvar().subscribe(resposta => {
      this.toastrService.success('Seguro gravado com sucesso!');
      this.router.navigate(['/seguros/listar']);
    }, erro => {
      this.toastrService.error('Não foi possível gravar o seguro: ' + erro);
    });
  }

  excluir() {
    if (!confirm(`Tem certeza que deseja excluir o seguro? Essa operação não poderá ser desfeita.`)) {
      return;
    }

    this.segurosService.excluir(this.seguroId).subscribe(resposta => {
      this.toastrService.success('Seguro excluído com sucesso!');
      this.router.navigate(['/seguros/listar']);
    }, erro => {
      this.toastrService.error('Não foi possível excluir o seguro: ' + erro);
    });
  }

  onSelecionarTipoSeguro(codigoTipo: number) {
    this.seguro.codigoTipo = codigoTipo;
  }

  onAlterouTipoCliente(tipoCliente: string) {
    this.seguro.cpfCnpj = '';
    this.tipoCliente = tipoCliente;
  }

  private salvar(): Observable<RespostaDadosApi<Seguro>> {
    if (this.seguroId > 0) {
      return this.segurosService.atualizar(this.seguroId, this.seguro);
    } else {
      return this.segurosService.criar(this.seguro);
    }
  }
}
