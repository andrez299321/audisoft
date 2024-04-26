import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Profesor, ResponseBaseProfesor } from 'src/app/models/profesor.models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfesoresService {

  constructor(private http: HttpClient) { }

  Get(): Observable<Profesor[]> 
  {

    return this.http.get<ResponseBaseProfesor>(`${environment.url_api}/Profesor`)
    .pipe(
      map( resp=> {
        return resp.response
      })
    );
  }

  GetPorId(id : number): Observable<Profesor> 
  {
    return this.http.get<ResponseBaseProfesor>(`${environment.url_api}/Profesor/${id}`)
    .pipe(
      map( resp => {
        return resp.response
      })
    );
  }

  Crear(data : Profesor): Observable<number>{  
    return this.http.post<ResponseBaseProfesor>(`${environment.url_api}/Profesor`, data)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  Actualizar(data : Profesor,id : number): Observable<number>{
    return this.http.put<ResponseBaseProfesor>(`${environment.url_api}/Profesor/${id}`,data)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  Delete(id : number): Observable<number> 
  {
    return this.http.delete<ResponseBaseProfesor>(`${environment.url_api}/Profesor/${id}`)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }
}
