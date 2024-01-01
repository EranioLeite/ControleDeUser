import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { login } from '../models/login';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { DadosLoginService } from './dados-login.service';
import { usuario } from '../models/usuariosModel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private url = `${environment.api}/api/Login`
  constructor(private httpClient: HttpClient, private dadosLogin: DadosLoginService) { }

  acessarSistema(dados: login){
    return this.httpClient.post<login>(this.url, dados)
   
  }
}
