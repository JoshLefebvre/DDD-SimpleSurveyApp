export interface Survey {
  entityId: string,
  surveyName: string;
  surveyQuestions: SurveyQuestion[];
}

export interface SurveyQuestion {
  entityId: string;
  questionText: string;
  questionType: QuestionTypes;
  userAnswer: string;
}

export interface ScaleQuestion extends SurveyQuestion {
  answers: number[];
  labels: string[];
  frequency: number[];
}

export interface SurveyQuestionAnswers {
  questionId: string;
  answer: string;
}

export enum QuestionTypes {
  ScaleQuestion = 2,
  TextQuestion = 3,
  MultiSelectQuestion = 1,
  MultipleChoice = 0
}
