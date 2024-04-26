import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from 'src/app/material/materia.module';


@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent
  ],
  exports:[
    FooterComponent,
    HeaderComponent,
    MaterialModule
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule 
  ]
})
export class SharedModule { }
