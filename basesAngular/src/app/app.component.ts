import { Component } from '@angular/core';
import { AcumuladorComponent } from './acumulador/acumulador.component';
import { ClientesModule } from './clientes/clientes.module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  imports: [AcumuladorComponent, ClientesModule],
  styleUrl: './app.component.css'
})
export class AppComponent {
  title: string = 'Bases de Angular';
}
