import { Component } from '@angular/core';
import { Todo } from 'src/models/Todo.model';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  
})
export class AppComponent {
  public formulario: FormGroup;
  
  constructor() {
    
  }
}
