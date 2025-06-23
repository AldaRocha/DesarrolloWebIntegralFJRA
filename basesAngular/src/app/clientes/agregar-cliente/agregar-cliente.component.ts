import { Component, EventEmitter, Output } from '@angular/core';
import { ICliente } from '../interfaces/cliente';
import { ClientesService } from '../clientes.service';

@Component({
  selector: 'app-agregar-cliente',
  standalone: false,
  templateUrl: './agregar-cliente.component.html',
  styleUrl: './agregar-cliente.component.css'
})
export class AgregarClienteComponent {
  nuevo: ICliente = {
    nombre: "",
    credito: 0
  }

  constructor(private clientesService: ClientesService){

  }

  agregar(){
    if (this.nuevo.nombre.trim().length === 0){
      return;
    }

    if (this.nuevo.credito === null){
      return;
    }

    this.clientesService.agregarCliente(this.nuevo);

    this.nuevo = {
      nombre: "",
      credito: 0
    }
  }
}
