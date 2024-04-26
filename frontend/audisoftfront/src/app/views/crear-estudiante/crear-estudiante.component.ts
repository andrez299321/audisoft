import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Estudiante } from 'src/app/models/estudiante.models';
import { EstudiantesService } from 'src/app/services/estudiantes/estudiantes.service';

@Component({
  selector: 'app-crear-estudiante',
  templateUrl: './crear-estudiante.component.html',
  styleUrls: ['./crear-estudiante.component.css']
})
export class CrearEstudianteComponent implements OnInit {


  form!: FormGroup;
  estudiante!: Estudiante;
  id: number = 0;
  titulo: string = "";

  constructor(private formBuilder: FormBuilder,private estudiantesServices: EstudiantesService, private router: Router,private activateRoute: ActivatedRoute) { }
  
 


  ngOnInit(): void {

    this.form = this.formBuilder.group(
      {
        id : [''],
        nombre : ['', [Validators.required]]
      }
    );

    this.id = Number(this.activateRoute.snapshot.paramMap.get('id'))|0;
    this.form.controls['id'].disable();
    if(this.id != null && this.id != 0){
      this.titulo="Editar Estudiantes";
      this.estudiantesServices.GetPorId(this.id).subscribe(item=>{
        console.log(item);
        this.form.controls['id'].setValue(this.id);
        this.form.controls['nombre'].setValue(item.nombre);
      })
    }
    else
    {
      this.form.controls['id'].disable();
      this.form.controls['id'].setValue(0);
      this.titulo="Agregar Estudiantes";
    }

  }

  
  Save( event: Event): any{

    event.preventDefault();
    if (this.form.valid){
      this.form.controls['id'].enable();
      this.estudiante = this.form.value;
      console.log(this.estudiante);

      
      if(this.estudiante.id != 0 ){


        this.estudiantesServices.Actualizar(this.estudiante,this.estudiante.id).subscribe( (item) => {
          console.log('put');
          console.log(item);
          this.router.navigate(['./Estudiantes']);
        });
      }else{
          console.log('post');
          this.estudiantesServices.Crear(this.estudiante).subscribe( (item) => {
          console.log(item);
          this.router.navigate(['./Estudiantes']);
        });
      }

    }
    else{
      alert('datos invalidos');
    } 
  }

}
