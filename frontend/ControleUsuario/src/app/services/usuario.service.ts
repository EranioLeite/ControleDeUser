import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { usuario } from '../models/usuariosModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private url = `${environment.api}/usuarios`
  
  constructor(private httpClient: HttpClient) {
    
   }
  listarUsuario(): Observable<any>{
    return this.httpClient.get<usuario[]>(this.url)
  }
  cadastrarUsuario(usuario: usuario){
    return this.httpClient.post<usuario>(this.url, usuario)
  }
  getUserid(id: number): Observable<any>{
    return this.httpClient.get<usuario>(this.url+'/'+id)
  }
  editarUsuario(id:number, usuario: usuario){
    return this.httpClient.put<usuario>(this.url+'/'+id, usuario)
  }
  remover(id:number){
    return this.httpClient.delete<void>(`${this.url}/${id}`);
  }
}
