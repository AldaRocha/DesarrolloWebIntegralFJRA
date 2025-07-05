import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'inicio',
        loadChildren: () => import('./inicio/inicio.routes').then(m => m.routes)
    },
    {
        path: 'productos',
        loadChildren: () => import('./producto/producto.routes').then(m => m.routes)
    },
    {
        path: '',
        redirectTo: 'inicio',
        pathMatch: 'full'
    }
];
