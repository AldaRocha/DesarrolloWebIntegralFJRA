import { Routes } from '@angular/router';

export const routes: Routes = [
{
    path: 'empleados',
    loadChildren: () =>
        import('./empleados/empleados.routes').then(m => m.EMPLEADOS_ROUTES)
    }
];
