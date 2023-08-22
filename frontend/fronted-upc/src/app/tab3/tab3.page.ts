import { Component } from '@angular/core';
import { Producto } from '../entidades/Producto';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {

  public Nombre = ""
  public IdCategoria = ""

  public listaProducto: Producto[] = []

  constructor() {

    let producto: Producto = new Producto();
    producto.Nombre = "Chocolate"
    producto.IdCategoria = "10"

    this.listaProducto.push(producto)
    this.listaProducto.push(producto)

  }


  public addProducto(){

  }

}
