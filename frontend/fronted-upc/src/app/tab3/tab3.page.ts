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

  public nombre = ""
  public idCategoria = ""

  public listaProducto: Producto[] = []

  constructor(private productoService: ProductoService) {
    this.GetProductoFromBackend();
  }

  private GetProductoFromBackend(){
    this.productoService.GetAll().subscribe({
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

  public addProducto(){
    this.AddProductoFromBackend(this.nombre, this.idCategoria)
  }

  private AddProductoFromBackend(nombre: string, idCategoria: string){

    var usuarioEntidad = new Producto();
    usuarioEntidad.nombre = nombre;
    usuarioEntidad.idCategoria = idCategoria;

    this.productoService.Add(usuarioEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego un PRODUCTO con exito ");
              this.GetProductoFromBackend();//Se actualize el listado
              this.nombre = "";
              this.idCategoria = "";
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