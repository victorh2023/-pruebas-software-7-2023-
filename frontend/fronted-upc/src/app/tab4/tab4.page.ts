import { Component } from '@angular/core';
import { CarritoCompra } from '../entidades/CarritoCompra';
import { CarritoCompraService } from '../servicios-backend/carrito-compra/carrito-compra.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab4',
  templateUrl: 'tab4.page.html',
  styleUrls: ['tab4.page.scss']
})
export class Tab4Page {

  public fecha = ""
  public idUsuarios = ""
  
  public listaCarritoCompra: CarritoCompra[] = []

  constructor(private carritoCompraService: CarritoCompraService) {

    this.GetCarritoCompraFromBackend();
  }

  private GetCarritoCompraFromBackend(){
    this.carritoCompraService.GetAll().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaCarritoCompra = response.body;
            console.log(this.listaCarritoCompra)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public addCarritoCompra(){
   this.addCarritoCompraFromBackend(this.fecha, this.idUsuarios)
  }

  private addCarritoCompraFromBackend(fecha: string, idUsuarios: string){

    var carritoCompraEntidad = new CarritoCompra();
    carritoCompraEntidad.fecha = fecha;
    carritoCompraEntidad.idUsuarios = idUsuarios;

    this.carritoCompraService.Add(carritoCompraEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego la carrito con exito");
              this.GetCarritoCompraFromBackend();//Se actualize el listado
              this.fecha = "";
              this.idUsuarios = "";
          }else{
              alert("Al agregar la Carrito fallo exito");
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