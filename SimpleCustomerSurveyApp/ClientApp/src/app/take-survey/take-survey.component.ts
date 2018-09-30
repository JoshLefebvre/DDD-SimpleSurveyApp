import { Component, Inject } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'take-survey',
  templateUrl: './take-survey.component.html'
})
export class TakeSurveyComponent {

  private survey: Survey;
  public questionTypes: questionTypes;
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

    http.get<Survey>(`${baseUrl}api/Survey/0`).subscribe(result => {
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

interface Survey {
  entityId: string,
  surveyName: string;
  surveyQuestions: SurveyQuestion[];
}

interface SurveyQuestion {
  entityId: string;
  questionText: string;
  questionType: questionTypes;
  userAnswer: string;
}

interface SurveyQuestionAnswers {
  questionId: string;
  answer: string;
}

export enum questionTypes {
  ScaleQuestion = 0,
  TextQuestion = 1,
  MultiSelectQuestion =2,
  MultipleChoice = 3
}


