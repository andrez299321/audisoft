import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { EstudiantesService } from 'src/app/services/estudiantes/estudiantes.service';
import { Estudiante } from 'src/app/models/estudiante.models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.component.html',
  styleUrls: ['./estudiantes.component.css']
})
export class EstudiantesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'nombre','actions'];
  estudiante : Estudiante[] =[];
  dataSource = new MatTableDataSource(this.estudiante);

  
  
  constructor(private estudiantesServices: EstudiantesService,private router: Router) {
    
  }

  ngOnInit(): void {
    this.refresh();
  }
  
  refresh():void{
    this.estudiantesServices.Get().subscribe(item => {
      console.log(item);
      this.estudiante = item;
      this.dataSource = new MatTableDataSource(this.estudiante);
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  Delete(id : number){
    this.estudiantesServices.Delete(id).subscribe(item => {
      console.log(item);
      if(item==0)
      {
        alert("Se elimino correctamente");
        this.refresh();
      }
      else
      {
        alert("No se puede eliminar este registro");
      }
    });
  }
}
