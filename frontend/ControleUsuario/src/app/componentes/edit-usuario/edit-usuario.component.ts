import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { usuario } from '../../models/usuariosModel';
import { UsuarioService } from '../../services/usuario.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
@Component({
  selector: 'app-edit-usuario',
  templateUrl: './edit-usuario.component.html',
  styleUrl: './edit-usuario.component.css'
})
export class EditUsuarioComponent implements OnInit{
  usuario!: usuario
  retorno: any = {}
  id: number = 0
  botao: string ="Cadastrar"
  formulario!: FormGroup
  constructor(private userService: UsuarioService, private route: ActivatedRoute, private router: Router){
    
  }
  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if(id != 0){
      this.userService.getUserid(id).subscribe(usuario => this.retorno = usuario)
      this.usuario = this.retorno.tRetorno
      this.id = this.usuario.id!;
      console.log(this.id)
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
    
    values.id = this.id
    console.log(values)
    this.userService.editarUsuario(this.id, values).subscribe(_ => this.router.navigate(['']))
  }
}
