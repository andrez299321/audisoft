import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatBadgeModule} from '@angular/material/badge';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table'; 
import {MatFormField} from '@angular/material/form-field'; 
import {MatStepperModule} from '@angular/material/stepper'; 
import {MatGridListModule} from '@angular/material/grid-list';
import {MatMenuModule} from '@angular/material/menu';
import {MatDialogModule,MatDialog, MatDialogRef} from '@angular/material/dialog';
import { MatFormFieldModule } from "@angular/material/form-field";
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatChipsModule} from '@angular/material/chips';
import { MatTableDataSource } from '@angular/material/table';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatButtonModule,
    MatToolbarModule,
    MatBadgeModule,
    MatIconModule,
    MatCardModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatStepperModule,
    MatGridListModule,
    MatMenuModule,
    MatFormFieldModule,
    MatDialogModule,
    MatButtonToggleModule,
    MatExpansionModule,
    MatChipsModule
    
    
  ],
  exports: [
    MatButtonModule,
    MatToolbarModule,
    MatBadgeModule,
    MatIconModule,
    MatCardModule,
    MatInputModule,
    MatSidenavModule,
    MatRadioModule,
    MatSelectModule,
    MatListModule,
    MatTableModule,
    MatStepperModule,
    MatGridListModule,
    MatFormField,
    MatFormFieldModule,
    MatMenuModule,
    MatDialogModule,
    MatButtonToggleModule, 
    MatExpansionModule,
    MatChipsModule
    
  ]
})
export class MaterialModule { }