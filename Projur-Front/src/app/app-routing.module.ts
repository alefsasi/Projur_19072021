import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsuarioCreateComponent } from './usuario/usuario-create/usuario-create.component';
import { UsuarioListComponent } from './usuario/usuario-list/usuario-list.component';
import { UsuarioUpdateComponent } from './usuario/usuario-update/usuario-update.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'index' },
  { path: 'index', component: HomeComponent },
  { path: 'usuario/criar', component: UsuarioCreateComponent},
  { path: 'usuario/editar/:id', component: UsuarioUpdateComponent},
  { path: 'usuario/listar', component: UsuarioListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
