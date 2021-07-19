import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UsuarioListComponent } from './usuario/usuario-list/usuario-list.component';
import { UsuarioCreateComponent } from './usuario/usuario-create/usuario-create.component';
import { MensagesErrorComponent } from './mensages-error/mensages-error.component';
import { UsuarioFormComponent } from './usuario/usuario-form/usuario-form.component';
import { UsuarioUpdateComponent } from './usuario/usuario-update/usuario-update.component';
import { FormsModule } from '@angular/forms';
import { UsuarioService } from './usuario/shared/services/usuario.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UsuarioListComponent,
    UsuarioCreateComponent,
    MensagesErrorComponent,
    UsuarioFormComponent,
    UsuarioUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
  ],
  providers: [UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
