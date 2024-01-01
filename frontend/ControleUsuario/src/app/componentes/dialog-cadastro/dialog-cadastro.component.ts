import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service';
import { Router, ActivatedRoute } from '@angular/router';
import { usuario } from '../../models/usuariosModel';
@Component({
  selector: 'app-dialog-cadastro',
  templateUrl: './dialog-cadastro.component.html',
  styleUrl: './dialog-cadastro.component.css'
})
export class DialogCadastroComponent {
  usuario!: usuario
  retorno: any = {}
  botao: string ="Cadastrar"
  formulario!: FormGroup
  constructor(private userService: UsuarioService, private route: ActivatedRoute, private router: Router){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if(id != 0){
      this.userService.getUserid(id).subscribe(usuario => this.retorno = usuario)
      this.usuario = this.retorno.tRetorno
      this.botao = "Atualizar"
    }
    this.formulario = new FormGroup({
      nome: new FormControl(this.usuario ? this.usuario.nome: '', Validators.required),
      sobrenome : new FormControl(this.usuario ? this.usuario.sobrenome: '', Validators.required),
      email: new FormControl(this.usuario ? this.usuario.email: '', [Validators.email, Validators.required]),
      senha: new FormControl(this.usuario ? this.usuario.senha: '', Validators.required),
      nivelAcesso: new FormControl(this.usuario ? this.usuario.nivelAcesso: '1', Validators.required),
    })
  }
  voltar(){
    this.router.navigate([''])
}

  tiposAcesso = [
    { nome: 'Comum', valor: 1 },
    { nome: 'Admin', valor: 2 },
  ];
  onSubmit(values:any){
    console.log(values)
    this.userService.cadastrarUsuario(values).subscribe(_ => this.router.navigate(['']))
  }
}
