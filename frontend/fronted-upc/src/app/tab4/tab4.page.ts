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

  public Fecha = ""
  public IdUsuario = ""

  public listaCarritoCompra: CarritoCompra[] = []

  constructor(private CarritoCompraService: CarritoCompraService) {
    this.getCarritoCompraFromBackend();
  }

  private getCarritoCompraFromBackend(){
    this.CarritoCompraService.GetCarritoCompra().subscribe({
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

    this.AddCarritoCompraFromBackend(this.Fecha, this.IdUsuario)
  }

  private AddCarritoCompraFromBackend(Fecha: string, IdUsuario: string){

    var CarritoCompraEntidad = new CarritoCompra();
    CarritoCompraEntidad.Fecha = Fecha;
    CarritoCompraEntidad.IdUsuario = IdUsuario;

    this.CarritoCompraService.AddCarritoCompra(CarritoCompraEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego un CARRITO COMPRA con exito ");
              this.getCarritoCompraFromBackend();//Se actualize el listado
              this.Fecha = "";
              this.IdUsuario = "";
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