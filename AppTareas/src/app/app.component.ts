import { NgFor, NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ITarea } from './interfaces/tarea';
import { TareaService } from './services/tarea.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, FormsModule, NgFor, NgIf, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  listaTareas: ITarea[] = [];
  isResultLoaded = false;
  isUpdateActive = false;
  nombreTarea: string = "";
  IDTareaActual: number = 0;

  constructor(private _tareasService: TareaService){
    this.obtenerTareas();
  }

  obtenerTareas(){
    this._tareasService.getList().subscribe({
      next: (data) => {
        this.listaTareas = data;
        this.isResultLoaded = true;
      }, error:(e) => {
        console.error(e);
      }
    })
  }
}
