import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TituloComponent } from './titulo.component';
import { FormularioComponent } from './formulario.component';
import { ListadoComponent } from './listado.component';

@Component({
    selector: 'app-layout',
    templateUrl: './layout.component.html',
    standalone: true,
    imports: [CommonModule, TituloComponent, FormularioComponent, ListadoComponent]
})
export class LayoutComponent {
    selectedEmpleadoId: number | null = null;
    refrescarListado = false;

    onEditar(id: number) {
        this.selectedEmpleadoId = id;
        this.refrescarListado = !this.refrescarListado;
    }

    onGuardado() {
        this.selectedEmpleadoId = null;
        this.refrescarListado = !this.refrescarListado;
    }

    onCancelado() {
        this.selectedEmpleadoId = null;
    }
}
