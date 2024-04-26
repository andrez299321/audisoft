import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Estudiante } from 'src/app/models/estudiante.models';
import { Nota } from 'src/app/models/nota.model';
import { Profesor } from 'src/app/models/profesor.models';
import { EstudiantesService } from 'src/app/services/estudiantes/estudiantes.service';
import { NotasService } from 'src/app/services/notas/notas.service';
import { ProfesoresService } from 'src/app/services/profesores/profesores.service';

@Component({
  selector: 'app-crear-nota',
  templateUrl: './crear-nota.component.html',
  styleUrls: ['./crear-nota.component.css']
})
export class CrearNotaComponent implements OnInit {

  form!: FormGroup;
  nota!: Nota;
  id: number = 0;
  titulo: string = "";
  estudiantes : Estudiante[] = [];
  profesores : Profesor[] = [];

  constructor(private formBuilder: FormBuilder,
    private notasService: NotasService,
     private router: Router,
     private activateRoute: ActivatedRoute,
     private profesoresService : ProfesoresService,
     private estudianteService: EstudiantesService
    ) { }
  
 


  ngOnInit(): void {

    this.form = this.formBuilder.group(
      {
        id : [''],
        nombre : ['', [Validators.required]],
        valor : ['', [Validators.required]],
        idEstudiante : ['', [Validators.required]],
        idProfesor : ['', [Validators.required]]
      }
    );

    this.estudianteService.Get().subscribe(item=>{
      this.estudiantes = item;
    });

    this.profesoresService.Get().subscribe(item=>{
      this.profesores = item;
    });

    this.id = Number(this.activateRoute.snapshot.paramMap.get('id'))|0;
    this.form.controls['id'].disable();
    if(this.id != null && this.id != 0){
      this.titulo="Editar Notas";
      this.notasService.GetPorId(this.id).subscribe(item=>{
        console.log(item);
        this.form.controls['id'].setValue(this.id);
        this.form.controls['nombre'].setValue(item.nombre);
        this.form.controls['valor'].setValue(item.valor);
        this.form.controls['idEstudiante'].setValue(item.idEstudiante);
        this.form.controls['idProfesor'].setValue(item.idProfesor);
        console.log(item.idEstudiante);
        console.log(this.form.value);
      })
    }
    else
    {
      this.form.controls['id'].setValue(0);
      this.titulo="Agregar Notas";
    }

  }

  
  Save( event: Event): any{

    event.preventDefault();
    if (this.form.valid){
      this.form.controls['id'].enable();
      this.nota = this.form.value;
      console.log(this.nota);

      
      if(this.nota.id != 0 )
      {
        this.notasService.Actualizar(this.nota,this.nota.id).subscribe( (item) => {
          console.log('put');
          console.log(item);
          this.router.navigate(['./Notas']);
        });
      }
      else
      {
        console.log('post');
        this.notasService.Crear(this.nota).subscribe( (item) => {
          console.log(item);
          this.router.navigate(['./Notas']);
        });
      }

    }
    else{
      alert('datos invalidos');
    } 
  }

}
