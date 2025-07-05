import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Producto } from '../interface/producto';

@Injectable({
    providedIn: 'root'
})
export class ProductoService {
    private endPoint: string = environment.endPoint;
    private apiUrl: string = this.endPoint + "Productos/";

    constructor(private http: HttpClient) {

    }

    getList(): Observable<Producto[]>{
        return this.http.get<Producto[]>(`${this.apiUrl}`);
    }

    add(request: Producto): Observable<Producto>{
        return this.http.post<Producto>(`${this.apiUrl}`, request);
    }

    update(request: Producto): Observable<void>{
        return this.http.put<void>(`${this.apiUrl}${request.productoId}`, request);
    }

    delete(productoId: number): Observable<void>{
        return this.http.delete<void>(`${this.apiUrl}${productoId}`);
    }
}
