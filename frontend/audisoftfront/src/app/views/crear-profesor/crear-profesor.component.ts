import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Profesor } from 'src/app/models/profesor.models';
import { ProfesoresService } from 'src/app/services/profesores/profesores.service';


@Component({
  selector: 'app-crear-profesor',
  templateUrl: './crear-profesor.component.html',
  styleUrls: ['./crear-profesor.component.css']
})
export class CrearProfesorComponent implements OnInit {

  form!: FormGroup;
  estudiante!: Profesor;
  id: number = 0;
  titulo: string = "";

  constructor(private formBuilder: FormBuilder,private profesoresService: ProfesoresService, private router: Router,private activateRoute: ActivatedRoute) { }
  
 


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
      this.titulo="Editar Profesore";
      this.profesoresService.GetPorId(this.id).subscribe(item=>{
        console.log(item);
        this.form.controls['id'].setValue(this.id);
        this.form.controls['nombre'].setValue(item.nombre);
      })
    }
    else
    {
      this.form.controls['id'].disable();
      this.form.controls['id'].setValue(0);
      this.titulo="Agregar Profesore";
    }

  }

  
  Save( event: Event): any{

    event.preventDefault();
    if (this.form.valid){
      this.form.controls['id'].enable();
      this.estudiante = this.form.value;
      console.log(this.estudiante);

      
      if(this.estudiante.id != 0 ){


        this.profesoresService.Actualizar(this.estudiante,this.estudiante.id).subscribe( (item) => {
          console.log('put');
          console.log(item);
          this.router.navigate(['./Profesores']);
        });
      }else{
          console.log('post');
          this.profesoresService.Crear(this.estudiante).subscribe( (item) => {
          console.log(item);
          this.router.navigate(['./Profesores']);
        });
      }

    }
    else{
      alert('datos invalidos');
    } 
  }

}
