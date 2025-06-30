import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmpleadoService } from './empleado.service';
import { Empleado } from '../interfaces/empleado';

@Component({
    selector: 'app-listado',
    templateUrl: './listado.component.html',
    standalone: true,
    imports: [CommonModule]
})
export class ListadoComponent implements OnInit, OnChanges {
    empleados: Empleado[] = [];
    @Input() refrescar = false;
    @Output() editar = new EventEmitter<number>();
    @Output() eliminado = new EventEmitter<void>();

    constructor(private service: EmpleadoService) {

    }

    ngOnInit(): void {
        this.cargar();
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['refrescar'] && !changes['refrescar'].firstChange) {
            this.cargar();
        }
    }

    cargar() {
        this.service.getAll().subscribe(data => this.empleados = data);
    }

    eliminar(id: number) {
        if (confirm('¿Seguro que deseas eliminar este empleado?')) {
            this.service.delete(id).subscribe(() => {
                this.eliminado.emit();
                this.cargar();
            });
        }
    }

    editarEmpleado(id: number) {
        this.editar.emit(id);
    }
}
