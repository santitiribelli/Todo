import { TodoToCreate } from './_interfaces/TodoToCreate.model';
import { Todo } from './_interfaces/todo.model';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isCreate: boolean;
  descripcion: string;
  estado: boolean;
  todo: TodoToCreate;
  todos: Todo[] = [];
  response: {dbPath: ''};

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.isCreate = true;
  }

  onCreate = () => {
    this.todo = {
      descripcion: this.descripcion,
      estado: this.estado,
      imgPath: this.response.dbPath
    }

    this.http.post('https://localhost:44362/api/todo', this.todo)
    .subscribe({
      next: _ => {
        this.getTodos();
        this.isCreate = false;
      },
      error: (err: HttpErrorResponse) => console.log(err)
    });
  }

  private getTodos = () => {
    this.http.get('https://localhost:44362/api/todo')
    .subscribe({
      next: (res) => this.todos = res as Todo[],
      error: (err: HttpErrorResponse) => console.log(err)
    });
  }

  returnToCreate = () => {
    this.isCreate = true;
    this.descripcion = '';
    this.estado = false;
  }

  uploadFinished = (event) => { 
    this.response = event; 
  }

  public createImgPath = (serverPath: string) => { 
    return `https://localhost:44362/${serverPath}`; 
  }
}
