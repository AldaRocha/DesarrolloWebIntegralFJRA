import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductoService } from '../service/inicio.service';

@Component({
    selector: 'app-listado',
    templateUrl: './listado.component.html',
    standalone: true,
    imports: [CommonModule]
})
export class ListadoComponent implements OnInit{
    productos: any[] = [];

    constructor(private _rest: ProductoService) {

    }

    ngOnInit(): void {
        this._rest.getList().subscribe(data => this.productos = data);
    }
}
