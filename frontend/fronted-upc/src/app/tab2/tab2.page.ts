import { Component } from '@angular/core';
import { CategoriaProducto } from '../entidades/CategoriaProducto';
import { CategoriaProductoService } from '../servicios-backend/categoria-producto/categoria-producto.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  public nombre = ""
  public listaCategoria: CategoriaProducto[] = []

  constructor(private categoriaProductoService: CategoriaProductoService) {
    this.GetCategoriaFromBackend();
  }

  private GetCategoriaFromBackend(){
    this.categoriaProductoService.GetAll().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaCategoria = response.body;
            console.log(this.listaCategoria)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
  });
  }

  public addCategoria(){
   this.AddCategoriaProductoFromBackend(this.nombre)
  }

  private AddCategoriaProductoFromBackend(nombre: string){

    var usuarioEntidad = new CategoriaProducto();
    usuarioEntidad.nombre = nombre;

    this.categoriaProductoService.Add(usuarioEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego la CATEGORIA con exito :)");
              this.GetCategoriaFromBackend();//Se actualize el listado
              this.nombre = "";
          }else{
              alert("Al agregar la CATEGORIA fallo exito :(");
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