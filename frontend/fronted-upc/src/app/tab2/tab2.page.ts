import { Component } from '@angular/core';
import { CategoriaProducto } from '../entidades/CategoriaProducto';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  public Nombre = ""

  public listaCategoriaProducto: CategoriaProducto[] = []

  constructor() {

    let categoriaProducto: CategoriaProducto = new CategoriaProducto();
    categoriaProducto.Nombre = "Ropero"

    this.listaCategoriaProducto.push(categoriaProducto)
    this.listaCategoriaProducto.push(categoriaProducto)

  }


  public addCategoriaProducto(){

  }

}
