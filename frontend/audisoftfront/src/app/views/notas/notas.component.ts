import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Nota, ReporteNota } from 'src/app/models/nota.model';
import { NotasService } from 'src/app/services/notas/notas.service';

@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.css']
})
export class NotasComponent implements OnInit {

  displayedColumns: string[] = ['id', 'nombre','valor','profesor','estudiante','actions'];
  notas : ReporteNota[] =[];
  dataSource = new MatTableDataSource(this.notas);

  
  
  constructor(private notasService: NotasService) {
    
  }

  ngOnInit(): void {
    this.refresh();
  }

  refresh():void{
    this.notasService.Get().subscribe(item => {
      console.log(item);
      this.notas = item;
      this.dataSource = new MatTableDataSource(this.notas);
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  Delete(id : number){
    this.notasService.Delete(id).subscribe(item => {
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
