import { Component } from '@angular/core';
import { Usuarios } from '../entidades/usuarios';
import { UsuariosService } from '../servicios-backend/usuarios/usuarios.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {

  public nombreCompleto = ""
  public userName = ""
  public password = ""

  public listaUsuarios: Usuarios[] = []

  constructor(private usuariosService: UsuariosService) {
   /*
    let usuario: Usuarios = new Usuarios();
    usuario.nombreCompleto = "Eddy Escalante"
    usuario.userName = "eescalante"
    usuario.password = "2023"

    this.listaUsuarios.push(usuario)
    this.listaUsuarios.push(usuario)
  */
    this.getUsuarios();
  }
  
  private getUsuarios(){
    this.usuariosService.GetUsuarios().subscribe({
      next: (response: HttpResponse<any>) => {
        this.listaUsuarios = response.body;

      //luego de llamar al servicio  
      },
      error: (error: any) => {
        console.log(error);

      //cuando falla el servicio  
      },
      complete: () => {
      //cuando termina todo  
      }
    });
  }

  public addUsuario(){

  }
}
