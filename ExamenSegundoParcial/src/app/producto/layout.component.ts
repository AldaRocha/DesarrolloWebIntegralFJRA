import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TituloComponent } from './titulo.component';
import { ListadoComponent } from './listado.component';
import { FooterComponent } from './footer.component';
import { BuscadorComponent } from './buscador.component';

@Component({
    selector: 'app-layout',
    standalone: true,
    templateUrl: './layout.component.html',
    imports: [CommonModule, TituloComponent, FooterComponent, ListadoComponent, BuscadorComponent] 
})
export class LayoutComponent {
    filtro: { texto: string; } = { texto: '' };

    filtroCambiado(nuevoFiltro: { texto: string; }) {
        this.filtro = nuevoFiltro;
    }
}
