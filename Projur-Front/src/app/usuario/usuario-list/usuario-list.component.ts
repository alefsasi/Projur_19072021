import { Component, OnInit, ViewChild } from '@angular/core';
import { MensagesErrorComponent } from 'src/app/mensages-error/mensages-error.component';
import { EscolaridadeEnum } from '../shared/model/Escolaridade.model';
import { Usuario } from '../shared/model/usuario.model';
import { UsuarioService } from '../shared/services/usuario.service';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrls: ['./usuario-list.component.css']
})
export class UsuarioListComponent implements OnInit {
  public usuarios: Usuario[];
  @ViewChild(MensagesErrorComponent) errorMsgComponent: MensagesErrorComponent;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.getListaUsuarios();
  }

  getListaUsuarios() {
    this.usuarioService.getUsuarios()
      .subscribe((result: any) => {
        if (result.success)
          this.usuarios = result.data;
        else
          this.errorMsgComponent.setError(result.message);

      }, () => { this.errorMsgComponent.setError('Falha ao buscar usuarios.'); });
  }

  getEscolaridade(id: number) {
    return EscolaridadeEnum[id];
  }

  deletaUsuario(id: number) {
    this.usuarioService.deleteUsuario(id)
      .subscribe((result: any) => {
        if (result.success)
          this.getListaUsuarios();
        else
          this.errorMsgComponent.setError(result.message);
      }, () => { this.errorMsgComponent.setError('Falha ao deletar usuário.'); });
  }

}
