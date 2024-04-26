import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Estudiante, ResponseBase } from 'src/app/models/estudiante.models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstudiantesService {

  constructor(private http: HttpClient) { }

  Get(): Observable<Estudiante[]> 
  {

    return this.http.get<ResponseBase>(`${environment.url_api}/Estudiante`)
    .pipe(
      map( resp=> {
        return resp.response
      })
    );
  }

  GetPorId(id : number): Observable<Estudiante> 
  {
    return this.http.get<ResponseBase>(`${environment.url_api}/Estudiante/${id}`)
    .pipe(
      map( resp => {
        return resp.response;
      })
    );
  }

  Crear(data : Estudiante): Observable<number>{  
    return this.http.post<ResponseBase>(`${environment.url_api}/Estudiante`, data)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  Actualizar(data : Estudiante,id : number): Observable<number>{

    return this.http.put<ResponseBase>(`${environment.url_api}/Estudiante/${id}`,data)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  Delete(id : number): Observable<number> 
  {    
    return this.http.delete<ResponseBase>(`${environment.url_api}/Estudiante/${id}`)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  
}
