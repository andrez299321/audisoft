import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutComponent } from './views/layout/layout.component';
import { HomeComponent } from './views/home/home.component';
import { MaterialModule } from './material/materia.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './views/shared/shared.module';
import { EstudiantesComponent } from './views/estudiantes/estudiantes.component';
import { ProfesoresComponent } from './views/profesores/profesores.component';
import { NotasComponent } from './views/notas/notas.component';
import { CrearEstudianteComponent } from './views/crear-estudiante/crear-estudiante.component';
import { CrearProfesorComponent } from './views/crear-profesor/crear-profesor.component';
import { CrearNotaComponent } from './views/crear-nota/crear-nota.component';
@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HomeComponent,
    EstudiantesComponent,
    ProfesoresComponent,
    NotasComponent,
    CrearEstudianteComponent,
    CrearProfesorComponent,
    CrearNotaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserAnimationsModule,
    SharedModule,
    MaterialModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
