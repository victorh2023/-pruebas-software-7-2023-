import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { CategoriaProducto } from 'src/app/entidades/CategoriaProducto';

@Injectable({
  providedIn: 'root'
})
export class CategoriaProductoService {

  PATH_BACKEND = "http://localhost:" + "5146"

  URL_GET = this.PATH_BACKEND + "/api/CategoriaProducto/GetAllCategoriaProducto";
  URL_ADD_CATEGORIA_PRODUCTO = this.PATH_BACKEND + "/api/CategoriaProducto/AddCategoriaProducto";

  constructor(private httpClient: HttpClient) {
  }

  public GetAll(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public Add(entidad: CategoriaProducto): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_CATEGORIA_PRODUCTO, entidad,
        { observe: 'response' })
      .pipe();
  }

}