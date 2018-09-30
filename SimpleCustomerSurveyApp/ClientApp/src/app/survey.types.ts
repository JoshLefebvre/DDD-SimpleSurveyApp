export interface Survey {
  entityId: string,
  surveyName: string;
  surveyQuestions: SurveyQuestion[];
}

export interface SurveyQuestion {
  entityId: string;
  questionText: string;
  questionType: questionTypes;
  userAnswer: string;
}

export interface SurveyQuestionAnswers {
  questionId: string;
  answer: string;
}

export enum QuestionTypes {
  ScaleQuestion = 0,
  TextQuestion = 1,
  MultiSelectQuestion = 2,
  MultipleChoice = 3
}
