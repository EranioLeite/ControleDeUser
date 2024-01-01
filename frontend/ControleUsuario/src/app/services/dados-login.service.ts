import { Injectable } from '@angular/core';
import { usuario } from '../models/usuariosModel';

@Injectable({
  providedIn: 'root'
})
export class DadosLoginService {
public dadosUsuario!: usuario


 public isAuthenticated():boolean{
  return Boolean(this.dadosUsuario?.id);
 }
}
