import { Component } from '@angular/core';

export interface Post {
  id: number;
  createDate: string;
  content: string;
  type: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 
}
