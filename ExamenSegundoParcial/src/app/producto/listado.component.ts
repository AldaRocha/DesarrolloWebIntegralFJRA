import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductoService } from '../service/inicio.service';

@Component({
    selector: 'app-listado',
    templateUrl: './listado.component.html',
    standalone: true,
    imports: [CommonModule]
})
export class ListadoComponent implements OnInit{
    @Input() filtro!: { texto: string; };

    items: any[] = [];

    itemsFiltrados = [...this.items];

    constructor(private _rest: ProductoService)
    {

    }
    
    async ngOnInit() {
        await this._rest.getList().subscribe(data => this.items = data);
        this.itemsFiltrados = this.items;
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['filtro'] && this.filtro) {
            this.aplicarFiltro(this.filtro);
        }
    }

    aplicarFiltro(filtro: { texto: string; }) {
        this.itemsFiltrados = this.items.filter(item =>
            item.nombre.toLowerCase().includes(filtro.texto)
        );
    }
}
