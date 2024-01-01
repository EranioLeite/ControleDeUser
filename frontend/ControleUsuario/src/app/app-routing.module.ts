import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './componentes/pages/home/home.component';
import { DialogCadastroComponent } from './componentes/dialog-cadastro/dialog-cadastro.component';
import { EditUsuarioComponent } from './componentes/edit-usuario/edit-usuario.component';
import { LoginComponent } from './componentes/login/login.component';

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path: '', component:HomeComponent },
  {path:'novousuario', component:DialogCadastroComponent},
  {path:'editarusuario/:id', component:EditUsuarioComponent},
  {path:'login', component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
