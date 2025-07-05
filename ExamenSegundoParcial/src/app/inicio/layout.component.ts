import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TituloComponent } from './titulo.component';
import { ListadoComponent } from './listado.component';
import { FooterComponent } from './footer.component';

@Component({
    selector: 'app-layout',
    standalone: true,
    templateUrl: './layout.component.html',
    imports: [CommonModule, TituloComponent, FooterComponent, ListadoComponent] 
})
export class LayoutComponent {

}
