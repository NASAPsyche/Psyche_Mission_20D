using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnswerData
{
    public static string answerData =
    @"{
       ""questions"": [
            {
              ""question"": ""Psyche is the name of?"",
              ""correct_answer"": ""An asteroid"",
              ""wrong_answer"": ""A person""
            },
            {
              ""question"": ""What are most asteroids made of?"",
              ""correct_answer"": ""Rock or ice"",
              ""wrong_answer"": ""Chocolate""
            },
            {
              ""question"": ""When is the launch of the Psyche spacecraft from Cape Canaveral, Florida?"",
              ""correct_answer"": ""launch is in 2022"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Who has been to the Psyche asteroid?"",
              ""correct_answer"": ""No one"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Does the Psyche asteroid have gravity?"",
              ""correct_answer"": ""Yes"",
              ""wrong_answer"": ""No""
            },
            {
              ""question"": ""How long will the Psyche Mission last?"",
              ""correct_answer"": ""3.4 years"",
              ""wrong_answer"": ""3.4 seconds""
            },
            {
              ""question"": ""What is the size of the spacecraft?"",
              ""correct_answer"": ""The size of one tennis court"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""What are the terrestrial planets?"",
              ""correct_answer"": ""Mercury, Venus, Earth and Mars"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""When will the Psyche spacecraft fly by Mars?"",
              ""correct_answer"": ""it will fly by in 2023"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""How many phases are there for the Psyche mission?"",
              ""correct_answer"": ""Four"",
              ""wrong_answer"": ""Three""
            },
            {
              ""question"": ""How long have we known what Psyche is made of?"",
              ""correct_answer"": ""Since 2010"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""When was the Psyche mission selected by NASA?"",
              ""correct_answer"": ""Jan 4, 2017"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""What company built the spacecraft?"",
              ""correct_answer"": ""Maxar Technologies"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""What will happen at the end of the mission?"",
              ""correct_answer"": ""The spacecraft will stay in orbit around Psyche"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""What is the Psyche asteroid orbiting?"",
              ""correct_answer"": ""The Sun"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Who is the mission led by?"",
              ""correct_answer"": ""Arizona State University"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Is Earth made of metal like Psyche?"",
              ""correct_answer"": ""Np"",
              ""wrong_answer"": ""Yes""
            },
            {
              ""question"": ""Who discovered the Psyche asteroid?"",
              ""correct_answer"": ""Annibale de Gasparis"",
              ""wrong_answer"": """"
            }
        ]
    }";

}

[Serializable]
public class QuestionList
{
    public List<Question> questions;
}

[Serializable]
public class Question
{
    public string question;
    public string correct_answer;
    public string wrong_answer;
}
