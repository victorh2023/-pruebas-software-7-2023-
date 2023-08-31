import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { ReservarCita } from 'src/app/entidades/ReservarCita';

@Injectable({
  providedIn: 'root'
})
export class ReservarCitaService {

  PATH_BACKEND = "http://localhost:" + "5146"

  URL_GET = this.PATH_BACKEND + "/api/ReservarCita/GetAllReservarCita";
  URL_ADD_RESERVAR_CITA = this.PATH_BACKEND + "/api/ReservarCita/AddReservarCita";

  constructor(private httpClient: HttpClient) {
  }

  public GetAll(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public Add(entidad: ReservarCita): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_RESERVAR_CITA, entidad,
        { observe: 'response' })
      .pipe();
  }
}