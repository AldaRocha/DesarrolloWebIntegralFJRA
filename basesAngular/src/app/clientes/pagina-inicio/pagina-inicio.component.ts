import { Component } from '@angular/core';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-pagina-inicio',
  standalone: false,
  templateUrl: './pagina-inicio.component.html',
  styleUrl: './pagina-inicio.component.css'
})
export class PaginaInicioComponent {

  nuevo: ICliente = {
    nombre: "Carlos",
    credito: 5000
  }

  agregar(){
    console.log("Llamada al método agregar");
  }
}
