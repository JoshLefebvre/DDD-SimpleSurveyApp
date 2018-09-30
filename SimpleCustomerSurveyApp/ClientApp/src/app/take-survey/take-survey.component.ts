import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Survey, QuestionTypes, SurveyQuestionAnswers } from '../survey.types';
import { Router } from "@angular/router";

@Component({
  selector: 'take-survey',
  templateUrl: './take-survey.component.html'
})
export class TakeSurveyComponent {

  public survey: Survey;
  public questionTypes: QuestionTypes;
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.http.get<Survey>(`${this.baseUrl}api/Survey/0`).subscribe(result => {
      this.survey = result;
    }, error => console.error(error));
  }

  public submitSurvey() {

    let answers: SurveyQuestionAnswers[];

    answers = this.survey.surveyQuestions.map(x => {
      return {
        questionId: x.entityId,
        answer: x.userAnswer,
      };
    });

    this.http.post(`${this.baseUrl}api/Survey/submit-survey`, { surveyId: this.survey.entityId, questions: answers}).subscribe(result => {
      //Navigate to results
      this.router.navigate(['/survey-results']); 
    }, error => console.error(error));
  }

  public counter(i: number) {
    return new Array(i);
  }

  public onSelectionChange(questionId: string, value: string) {

    let question = this.survey.surveyQuestions.find(x => x.entityId === questionId);
    question.userAnswer = value;
  }

}




