import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Nota, ReporteNota, ResponseBaseNota } from 'src/app/models/nota.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotasService {

  constructor(private http: HttpClient) { }

  Get(): Observable<ReporteNota[]> 
  {

    return this.http.get<ResponseBaseNota>(`${environment.url_api}/Nota`)
    .pipe(
      map( resp=> {
        return resp.response
      })
    );
  }

  GetPorId(id : number): Observable<Nota> 
  {
    return this.http.get<ResponseBaseNota>(`${environment.url_api}/Nota/${id}`)
    .pipe(
      map( resp => {
        return resp.response
      })
    );
  }

  Crear(data : Nota): Observable<number>{  
    return this.http.post<ResponseBaseNota>(`${environment.url_api}/Nota`, data)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  Actualizar(data : Nota,id : number): Observable<number>{
    let queryParams = new HttpParams();
    queryParams = queryParams.append("id",id);
    return this.http.put<ResponseBaseNota>(`${environment.url_api}/Nota/${id}`,data)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }

  Delete(id : number): Observable<number> 
  {    
    return this.http.delete<ResponseBaseNota>(`${environment.url_api}/Nota/${id}`)
    .pipe(
      map( resp=> {
        return resp.codigoDeError
      })
    );
  }
}
