import { Component, Input } from '@angular/core';
import { ClientesService } from '../clientes.service';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-listado-clientes',
  standalone: false,
  templateUrl: './listado-clientes.component.html',
  styleUrl: './listado-clientes.component.css'
})
export class ListadoClientesComponent {
  constructor(private clientesService: ClientesService){

  }

  get clientes(): ICliente[]{
    return this.clientesService.clientes;
  }
}
