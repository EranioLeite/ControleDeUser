import { Component, OnInit } from '@angular/core';
import { usuario } from '../../../models/usuariosModel';
import { UsuarioService } from '../../../services/usuario.service';
import { Router, ActivatedRoute} from '@angular/router';
import { Observable } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  user: usuario[] = []
  retorno: any = {}
   constructor(private userService: UsuarioService, private router: Router){
    this.obterListUser()
   }
    ngOnInit(): void {
      this.obterListUser()
    }

   obterListUser(){
     this.userService.listarUsuario()
     .subscribe(usuario => this.retorno = usuario)
     this.user = this.retorno.tRetorno
   }
   novoUser(){
    this.router.navigate(['/novousuario']);
   }

   alterarUsuario(usuario: usuario){
    console.log(usuario)
    this.router.navigate(['/editarusuario/'+usuario.id])
    //this.userService.getUserid(usuario).subscribe(_ => this.router.navigate(['/editarusuario/'+usuario.id]))
   }
   remover(id: number){
      this.userService.remover(id).subscribe(_ => this.obterListUser())
   }
}
