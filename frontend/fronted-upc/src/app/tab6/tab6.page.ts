import { Component } from '@angular/core';
import { ReservarCita } from '../entidades/ReservarCita';
import { ReservarCitaService } from '../servicios-backend/reservar-cita/reservar-cita.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab6',
  templateUrl: 'tab6.page.html',
  styleUrls: ['tab6.page.scss']
})
export class Tab6Page {

  public fechaCita = ""
  public horaCita = ""
  public motivoConsulta = ""
  public idUsuarios = ""
  public idOdontologia = ""

  public listaReservarCita: ReservarCita[] = []

  constructor(private reservarCitaService: ReservarCitaService) {
/*
    let usuario: Usuarios = new Usuarios();
    usuario.nombreCompleto = "Eddy Escalante"
    usuario.userName = "eescalante"
    usuario.password = "2023"

    this.listaUsuarios.push(usuario)
    this.listaUsuarios.push(usuario)
*/
    this.GetReservarCitaFromBackend();
  }

  private GetReservarCitaFromBackend(){
    this.reservarCitaService.GetAll().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaReservarCita = response.body;
            console.log(this.listaReservarCita)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public addReservarCita(){
   this.addReservarCitaFromBackend(this.fechaCita, this.horaCita, this.motivoConsulta, this.idUsuarios, this.idOdontologia)
  }

  private addReservarCitaFromBackend(fechaCita: string, horaCita: string, motivoConsulta: string, idUsuarios: string, idOdontologia: string){

    var reservarCitaEntidad = new ReservarCita();
    reservarCitaEntidad.fechaCita = fechaCita;
    reservarCitaEntidad.horaCita = horaCita;
    reservarCitaEntidad.motivoConsulta = motivoConsulta;
    reservarCitaEntidad.idUsuarios = idUsuarios;
    reservarCitaEntidad.idOdontologia = idOdontologia;

    this.reservarCitaService.Add(reservarCitaEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego la Reserva con exito");
              this.GetReservarCitaFromBackend();//Se actualize el listado
              this.fechaCita = "";
              this.horaCita = "";
              this.motivoConsulta = "";
              this.idUsuarios = "";
              this.idOdontologia = "";
          }else{
              alert("Al agregar la RESERVA fallo exito ");
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