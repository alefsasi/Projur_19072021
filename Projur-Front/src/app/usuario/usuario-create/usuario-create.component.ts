import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MensagesErrorComponent } from 'src/app/mensages-error/mensages-error.component';
import { ResultError } from '../shared/model/resultError.model';
import { Usuario } from '../shared/model/usuario.model';
import { UsuarioService } from '../shared/services/usuario.service';

@Component({
  selector: 'app-usuario-create',
  templateUrl: './usuario-create.component.html',
  styleUrls: ['./usuario-create.component.css']
})
export class UsuarioCreateComponent implements OnInit {
  @ViewChild(MensagesErrorComponent) errorMsgComponent: MensagesErrorComponent;

  constructor(private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {
  }
  createUsuario(usuario: Usuario) {
    this.usuarioService.createUsuario(usuario)
      .subscribe(
        (result: any) => {
          if (result.success)
            this.router.navigateByUrl('usuario/listar');
          else {
            const errors: ResultError[] = result.data
            errors.forEach(error => {
              this.errorMsgComponent.setError(error.message);
            });
          }
        },
        (err) => { this.errorMsgComponent.setError(err ? `Falha ao criar usuario: ${err.message}` : "Falha ao criar usuario"); });
  }
}
