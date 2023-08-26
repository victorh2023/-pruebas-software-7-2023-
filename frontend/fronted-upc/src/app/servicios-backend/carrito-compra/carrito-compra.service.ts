import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { CarritoCompra } from 'src/app/entidades/CarritoCompra';

@Injectable({
  providedIn: 'root'
})
export class CarritoCompraService {

  PATH_BACKEND = "http://localhost:" + "5146"

  URL_GET = this.PATH_BACKEND + "/api/CarritoCompra/GetAllCarritoCompra";
  URL_ADD_CARRITO_COMPRA = this.PATH_BACKEND + "/api/CarritoCompra/AddCarritoCompra";

  constructor(private httpClient: HttpClient) {
  }

  public GetCarritoCompra(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public AddCarritoCompra(entidad: CarritoCompra): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_CARRITO_COMPRA, entidad,
        { observe: 'response' })
      .pipe();
  }

}