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
  public idUsuario = ""

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
    this.AddCarritoCompraFromBackend(this.fecha, this.idUsuario)
  }

  private AddCarritoCompraFromBackend(fecha: string, idUsuario: string){

    var usuarioEntidad = new CarritoCompra();
    usuarioEntidad.fecha = fecha;
    usuarioEntidad.idUsuario = idUsuario;

    this.carritoCompraService.Add(usuarioEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego un CARRITO COMPRA con exito ");
              this.GetCarritoCompraFromBackend();//Se actualize el listado
              this.fecha = "";
              this.idUsuario = "";
          }else{
              alert("Al agregar el CARRITO COMPRA fallo exito ");
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