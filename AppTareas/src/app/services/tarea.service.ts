import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITarea } from '../interfaces/tarea';

@Injectable({
  providedIn: 'root'
})
export class TareaService {
  private endPoint: string = environment.endPoint;
  private apiUrl: string = this.endPoint + "Tareas/";

  constructor(private http: HttpClient) {

  }

  getList(): Observable<ITarea[]>{
    return this.http.get<ITarea[]>(`${this.apiUrl}`);
  }

  add(request: ITarea): Observable<ITarea>{
    return this.http.post<ITarea>(`${this.apiUrl}`, request);
  }

  update(request: ITarea): Observable<void>{
    return this.http.put<void>(`${this.apiUrl}/${request.tareaId}`, request);
  }

  delete(TareaId: number): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${TareaId}`);
  }
}
