import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Profesor } from 'src/app/models/profesor.models';
import { ProfesoresService } from 'src/app/services/profesores/profesores.service';

@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css']
})
export class ProfesoresComponent implements OnInit {

  displayedColumns: string[] = ['id', 'nombre','actions'];
  profesor : Profesor[] =[];
  dataSource = new MatTableDataSource(this.profesor);

  
  
  constructor(private profesoresService: ProfesoresService) {
    
  }

  ngOnInit(): void {
    this.refresh();
  }

  refresh():void{
    this.profesoresService.Get().subscribe(item => {
      console.log(item);
      this.profesor = item;
      this.dataSource = new MatTableDataSource(this.profesor);
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  Delete(id : number){
    this.profesoresService.Delete(id).subscribe(item => {
      console.log(item);
      if(item==0)
      {
        alert("Se elimino correctamente");
        this.refresh();
      }
      else
      {
        alert("No se puede eliminar este registro, comuniquese con el administrador");
      }
    });
  }

}
