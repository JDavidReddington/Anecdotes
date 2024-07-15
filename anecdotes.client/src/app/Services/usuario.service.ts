import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UsuarioRegistradoAn} from '../Models/UsuarioRegistradoAn';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  myAppUrl = 'https://localhost:7219/';  // LOCAL HOST DEL BACKEND EN ESTE CASO
  myApiUrl = 'api/UserOfRegs/';         // URL DE LA API

  constructor(private http: HttpClient) { }

  guardarUsuario(usuario: UsuarioRegistradoAn): Observable<UsuarioRegistradoAn> {
    return this.http.post<UsuarioRegistradoAn>(this.myAppUrl + this.myApiUrl, usuario);    
  }
}
