import { OnChanges, OnInit, ViewChild } from '@angular/core';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MensagesErrorComponent } from 'src/app/mensages-error/mensages-error.component';
import { Usuario } from '../shared/model/usuario.model';
import { Escolaridade, EscolaridadeEnum } from '../shared/model/Escolaridade.model';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html'
})
export class UsuarioFormComponent implements OnInit, OnChanges {
  @ViewChild(MensagesErrorComponent) errorMsgComponent: MensagesErrorComponent;

  public escolaridades: Escolaridade[];
  public nascimentoData: NgbDate;
  @Input() usuario: Usuario = <Usuario>{};
  @Output() outputUsuario: EventEmitter<Usuario> = new EventEmitter();

  constructor() { }
  ngOnInit(): void {
    this.getListaEscolaridades();
  }
  ngOnChanges() {
    if (this.usuario.dataNascimento) {
      const date = new Date(this.usuario.dataNascimento);
      this.nascimentoData = new NgbDate(date.getFullYear(), date.getMonth() + 1, date.getDate());
    }
  }
  getListaEscolaridades() {
    this.escolaridades = [];
    for (let num in EscolaridadeEnum) {
      if (parseInt(num) >= 0)
        this.escolaridades.push({ id: +num, descricao: EscolaridadeEnum[num] })
    }
  }

  onSubmit() {
    this.usuario.dataNascimento = this.ngDateToDate(this.nascimentoData);

    this.outputUsuario.emit(this.usuario);
  }
  validaEmail(email: string): boolean {

    const reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
    if (reg.test(email)) {
      return true;
    }

    return false;
  }
  validarData(date: any): boolean {
    try {
      if (!date) {
        return false;
      }
      const data = this.ngDateToDate(date);

      if (data >= new Date()) {
        return false
      }
      return true;
    } catch {
      return false;
    }

  }
  ngDateToDate(date: NgbDate): Date {
    return new Date(date.year, date.month - 1, date.day);

  }
}
