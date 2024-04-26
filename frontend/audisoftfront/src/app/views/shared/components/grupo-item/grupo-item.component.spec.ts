import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupoItemComponent } from './grupo-item.component';

describe('GrupoItemComponent', () => {
  let component: GrupoItemComponent;
  let fixture: ComponentFixture<GrupoItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GrupoItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GrupoItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
