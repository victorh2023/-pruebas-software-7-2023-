import { Component } from '@angular/core';
import { Producto } from '../entidades/producto';
import { ProductoService } from '../servicios-backend/producto/producto.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {

  public Nombre = ""
  public IdCategoria = ""

  public listaProducto: Producto[] = []

  constructor(private ProductoService: ProductoService) {
    this.GetProductoFromBackend();
  }

  private GetProductoFromBackend(){
    this.ProductoService.GetProducto().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaProducto = response.body;
            console.log(this.listaProducto)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public AddProducto(){

    this.AddProductoFromBackend(this.Nombre, this.IdCategoria)
  }

  private AddProductoFromBackend(Nombre: string, IdCategoria: string){

    var productoEntidad = new Producto();
    productoEntidad.Nombre = Nombre;
    productoEntidad.IdCategoria = IdCategoria;

    this.ProductoService.AddProducto(productoEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego un PRODUCTO con exito ");
              this.GetProductoFromBackend();//Se actualize el listado
              this.Nombre = "";
              this.IdCategoria = "";
          }else{
              alert("Al agregar el PRODUCTO fallo exito ");
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