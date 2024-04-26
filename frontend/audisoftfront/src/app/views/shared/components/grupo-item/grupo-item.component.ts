import { Component, Input, OnInit } from '@angular/core';
import { Grupo } from 'src/app/models/entity/Grupo.models';

@Component({
  selector: 'app-grupo-item',
  templateUrl: './grupo-item.component.html',
  styleUrls: ['./grupo-item.component.scss']
})
export class GrupoItemComponent implements OnInit {

  @Input() grupo: Grupo ;

  constructor() { }

  ngOnInit(): void {

    console.log(this.grupo);
    //console.log(this.grupo);
  }

}
