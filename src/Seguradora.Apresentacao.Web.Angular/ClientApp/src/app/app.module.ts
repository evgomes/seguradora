import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ListaSegurosComponent } from './components/lista-seguros/lista-seguros.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SegurosService } from './services/seguros.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListaSegurosComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'seguros/listar', pathMatch: 'full' },
      { path: 'seguros/listar', component: ListaSegurosComponent },
    ])
  ],
  providers: [
    SegurosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
