import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './views/layout/layout.component';
import { HomeComponent } from './views/home/home.component';
import { EstudiantesComponent } from './views/estudiantes/estudiantes.component';
import { ProfesoresComponent } from './views/profesores/profesores.component';
import { NotasComponent } from './views/notas/notas.component';
import { CrearEstudianteComponent } from './views/crear-estudiante/crear-estudiante.component';
import { CrearProfesorComponent } from './views/crear-profesor/crear-profesor.component';
import { CrearNotaComponent } from './views/crear-nota/crear-nota.component';

const routes: Routes = [
  { path: '',
     component: LayoutComponent,
     children:[
        { path : '',  redirectTo : 'home', pathMatch : 'full' },
        { path: 'home', component: HomeComponent},
        { path: 'Estudiantes', component: EstudiantesComponent},
        { path: 'Crear_estudiantes', component: CrearEstudianteComponent},
        { path: 'Crear_estudiantes/:id', component: CrearEstudianteComponent},
        { path: 'Crear_profesores', component: CrearProfesorComponent},
        { path: 'Crear_profesores/:id', component: CrearProfesorComponent},
        { path: 'Profesores', component: ProfesoresComponent}, 
        { path: 'Notas', component: NotasComponent},
        { path: 'Crear_nota', component: CrearNotaComponent},
        { path: 'Crear_nota/:id', component: CrearNotaComponent},
        { path: '**', pathMatch: 'full', component: HomeComponent }

      ]  
  }, 
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
