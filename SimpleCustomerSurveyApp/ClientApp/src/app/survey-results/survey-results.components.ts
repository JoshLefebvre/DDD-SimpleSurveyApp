import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Survey, QuestionTypes, SurveyQuestion, ScaleQuestion } from '../survey.types';

@Component({
  selector: 'survey-results-component',
  templateUrl: './survey-results.component.html'
})
export class SurveyResultsComponent {
  public survey: Survey;
  public multipleChoiceQuestions: SurveyQuestion[] = [];
  public textQuestions: SurveyQuestion[] = [];
  public scaleQuestions: ScaleQuestion[] = [];

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.http.get<Survey>(`${this.baseUrl}api/Survey/0`).subscribe(result => {
      this.survey = result;

      this.survey.surveyQuestions.forEach(x => {
        switch (x.questionType) {
          case QuestionTypes.MultipleChoice:
            this.multipleChoiceQuestions.push(x);
            break;
          case QuestionTypes.TextQuestion:
            this.textQuestions.push(x);
            break;
          case QuestionTypes.ScaleQuestion:
            this.createPieChartData(x as ScaleQuestion);
            this.scaleQuestions.push(x as ScaleQuestion);
            break;
          default:
            break;
        }
      })

    }, error => console.error(error));
  }

  createPieChartData(question: ScaleQuestion) {
    let arr = question.answers;
    var a = [], b = [], prev;

    arr.sort();
    for (var i = 0; i < arr.length; i++) {
      if (arr[i] !== prev) {
        a.push(arr[i]);
        b.push(1);
      } else {
        b[b.length - 1]++;
      }
      prev = arr[i];
    }

    question.labels = a;
    question.frequency = b;
  }

}
