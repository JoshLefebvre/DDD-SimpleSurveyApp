import { Component, Inject } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'take-survey',
  templateUrl: './take-survey.component.html'
})
export class TakeSurveyComponent {

  public survey: Survey;
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

    http.get<Survey>(`${baseUrl}api/Survey/0`).subscribe(result => {
      this.survey = result;
    }, error => console.error(error));
  }

  public submitSurvey() {

  }

}

interface Survey {
  surveyName: string;
  surveyQuestions: SurveyQuestion[];
}

interface SurveyQuestion {
  questionText: string;
}
