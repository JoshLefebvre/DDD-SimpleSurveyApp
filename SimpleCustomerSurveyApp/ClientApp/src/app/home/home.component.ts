import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    //Create Survey on initialization
    this.http.post(baseUrl + 'api/Survey/create-survey', {}).subscribe(result => {
      let x = result;
    }, error => console.error(error));
  }
}
