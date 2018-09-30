import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Survey } from '../survey.types';

@Component({
  selector: 'survey-results-component',
  templateUrl: './survey-results.component.html'
})
export class SurveyResultsComponent {
  public survey: Survey;
  public multipleChoiceQuestions: any[];
  public textQuestions: any[];
  public scaleQuestions: any[];

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

    http.get<Survey>(`${baseUrl}api/Survey/0`).subscribe(result => {
      this.survey = result;


    }, error => console.error(error));
  }


}
