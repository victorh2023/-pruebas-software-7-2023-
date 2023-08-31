import { Component } from '@angular/core';
import { Odontologia } from '../entidades/Odontologia';
import { OdontologiaService } from '../servicios-backend/odontologia/odontologia.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab5',
  templateUrl: 'tab5.page.html',
  styleUrls: ['tab5.page.scss']
})
export class Tab5Page {

  public nombreCompleto = ""
  public direccion = ""
  public telefono = ""
  public especialidad = ""

  public listaOdontologia: Odontologia[] = []

  constructor(private odontologiaService: OdontologiaService) {
/*
    let usuario: Usuarios = new Usuarios();
    usuario.nombreCompleto = "Eddy Escalante"
    usuario.userName = "eescalante"
    usuario.password = "2023"

    this.listaUsuarios.push(usuario)
    this.listaUsuarios.push(usuario)
*/
    this.GetOdontologiaFromBackend();
  }

  private GetOdontologiaFromBackend(){
    this.odontologiaService.GetAll().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaOdontologia = response.body;
            console.log(this.listaOdontologia)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public addOdontologia(){
   this.addOdontologiaFromBackend(this.nombreCompleto, this.direccion, this.telefono, this.especialidad)
  }

  private addOdontologiaFromBackend(nombreCompleto: string, direccion: string, telefono: string, especialidad: string){

    var odontologiaEntidad = new Odontologia();
    odontologiaEntidad.nombreCompleto = nombreCompleto;
    odontologiaEntidad.direccion = direccion;
    odontologiaEntidad.telefono = telefono;
    odontologiaEntidad.especialidad = especialidad;

    this.odontologiaService.Add(odontologiaEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego el ODONTOLOGO con exito");
              this.GetOdontologiaFromBackend();//Se actualize el listado
              this.nombreCompleto = "";
              this.direccion = "";
              this.telefono = "";
              this.especialidad = "";
          }else{
              alert("Al agregar al ODONTOLOGO fallo exito ");
          }
      },
      error: (error: any) => {
          console.log(error);
      },
      complete: () => {
          //console.log('complete - this.AddUsuario()');
      },
  });
  }

}