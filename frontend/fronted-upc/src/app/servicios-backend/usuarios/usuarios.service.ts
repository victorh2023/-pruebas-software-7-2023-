import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  PATH_BACKEND = "http://localhost:" + "5146"

  URL_GET = this.PATH_BACKEND + "/api/Usuarios/GetAllUsuarios";

  constructor(private httpClient: HttpClient) {
  }

  public GetUsuarios(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

}