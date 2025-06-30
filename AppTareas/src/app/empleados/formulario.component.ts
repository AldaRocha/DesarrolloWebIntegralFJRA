import { Component, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmpleadoService } from './empleado.service';
import { Empleado } from '../interfaces/empleado';

@Component({
    selector: 'app-formulario',
    templateUrl: './formulario.component.html',
    standalone: true,
    imports: [CommonModule, FormsModule]
})
export class FormularioComponent implements OnChanges {
    @Input() empleadoId: number | null = null;
    @Output() guardado = new EventEmitter<void>();
    @Output() cancelado = new EventEmitter<void>();

    empleado: Empleado = {
        empleadoId: 0,
        nombre: '',
        correo: '',
        telefono: '',
        fechaNacimiento: '',
        sexo: ''
    };

    constructor(private service: EmpleadoService) {

    }

    ngOnChanges(): void {
        if (this.empleadoId) {
            this.service.getById(this.empleadoId).subscribe(e => this.empleado = e);
        } else {
            this.empleado = {
                empleadoId: 0,
                nombre: '',
                correo: '',
                telefono: '',
                fechaNacimiento: '',
                sexo: ''
            };
        }
    }

    guardar() {
        const operacion = this.empleadoId ? this.service.update(this.empleado) : this.service.create(this.empleado);
        operacion.subscribe(() => this.guardado.emit());
    }

    cancelar() {
        this.cancelado.emit();
    }
}
