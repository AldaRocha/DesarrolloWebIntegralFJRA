import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-buscardor',
    templateUrl: './buscador.component.html',
    standalone: true,
    imports: [CommonModule, FormsModule]
})
export class BuscadorComponent{
    busqueda = '';
    @Output() filtroCambiado = new EventEmitter<{ texto: string; }>();

    categoriaSeleccionada: string = '';

    filtrar() {
        this.emitirFiltro();
    }

    emitirFiltro() {
        this.filtroCambiado.emit({
            texto: this.busqueda.toLowerCase()
        });
    }

}
