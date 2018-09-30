import { Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    //Create Survey on initialization
    this.http.post(`${this.baseUrl}api/Survey/create-survey`, {}).subscribe(result => {
      let x = result;
    }, error => console.error(error));
  }
}
