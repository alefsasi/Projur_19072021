import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario.model';

@Injectable()
export class UsuarioService {

  constructor(private http: HttpClient) { }

  public apiUsuario = `${environment.urlApi}/usuario`;

  getUsuarios(): Observable<any> {
    const url = `${this.apiUsuario}`
    return this.http.get<any>(url);

  }
  getUsuariobyId(id: number): Observable<any> {
    const url = `${this.apiUsuario}/${id}`;
    return this.http.get<any>(url);
  }

  createUsuario(usuario: Usuario): Observable<any> {
    const url = `${this.apiUsuario}`;
    return this.http.post<any>(url, usuario);
  }

  updateUsuario(usuario: Usuario): Observable<any> {
    const url = `${this.apiUsuario}/${usuario.id}`;
    return this.http.put<any>(url, usuario);
  }

  deleteUsuario(id: number): Observable<any> {
    const url = `${this.apiUsuario}/${id}`;
    return this.http.delete<any>(url);
  }
}

