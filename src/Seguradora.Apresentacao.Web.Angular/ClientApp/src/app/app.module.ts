import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxMaskModule } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { ListaSegurosComponent } from './components/lista-seguros/lista-seguros.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SeguroFormComponent } from './components/seguro-form/seguro-form.component';
import { SelectTiposSeguroComponent } from './components/select-tipos-seguro/select-tipos-seguro.component';
import { SegurosService } from './services/seguros.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListaSegurosComponent,
    SeguroFormComponent,
    SelectTiposSeguroComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpModule,
    FormsModule,
    ToastrModule.forRoot(),
    NgxMaskModule.forRoot(),
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'seguros/listar', pathMatch: 'full' },
      { path: 'seguros/listar', component: ListaSegurosComponent },
      { path: 'seguros/editar/:id', component: SeguroFormComponent },
      { path: 'seguros/novo', component: SeguroFormComponent },
    ])
  ],
  providers: [
    SegurosService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
