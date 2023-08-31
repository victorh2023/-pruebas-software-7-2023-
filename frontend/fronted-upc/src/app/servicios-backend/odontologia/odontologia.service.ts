import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Odontologia } from 'src/app/entidades/Odontologia';

@Injectable({
  providedIn: 'root'
})
export class OdontologiaService {

  PATH_BACKEND = "http://localhost:" + "5146"

  URL_GET = this.PATH_BACKEND + "/api/Odontologia/GetAllOdontologia";
  URL_ADD_ODONTOLOGIA = this.PATH_BACKEND + "/api/Odontologia/AddOdontologia";

  constructor(private httpClient: HttpClient) {
  }

  public GetAll(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public Add(entidad: Odontologia): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_ODONTOLOGIA, entidad,
        { observe: 'response' })
      .pipe();
  }
}