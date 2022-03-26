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
              ""question"": ""Psyche is the name of a/an?"",
              ""correct_answer"": ""asteroid"",
              ""wrong_answer"": ""person""
            },
            {
              ""question"": ""What are most asteroids made of?"",
              ""correct_answer"": ""Rock"",
              ""wrong_answer"": ""Chocolate""
            },
            {
              ""question"": ""When is the launch of the Psyche spacecraft from Cape Canaveral, Florida?"",
              ""correct_answer"": ""Launch is in 2022"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Who has visited the Psyche asteroid?"",
              ""correct_answer"": ""No one"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Does the Psyche asteroid have gravity?"",
              ""correct_answer"": ""Yes"",
              ""wrong_answer"": ""No""
            },
            {
              ""question"": ""How long will it take the spacecraft to reach the asteroid?"",
              ""correct_answer"": ""3.4 years"",
              ""wrong_answer"": ""3.4 seconds""
            },
            {
              ""question"": ""The size of the spacecraft is close to a/an?"",
              ""correct_answer"": ""single tennis court"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""What is NOT considered a terrestrial planet?"",
              ""correct_answer"": ""Jupiter"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""When will the Psyche spacecraft fly by Mars?"",
              ""correct_answer"": ""It will fly by in 2023"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""How many phases are there for the Psyche mission?"",
              ""correct_answer"": ""Four"",
              ""wrong_answer"": ""Three""
            },
            {
              ""question"": ""When was the Psyche mission selected by NASA?"",
              ""correct_answer"": ""Selected in 2017"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""What company built the spacecraft?"",
              ""correct_answer"": ""Maxar Technologies"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Will the spacecraft return to Earth after the mission?"",
              ""correct_answer"": ""No"",
              ""wrong_answer"": ""Yes""
            },
            {
              ""question"": ""Where is the Psyche Asteroid?"",
              ""correct_answer"": ""Asteroid Belt"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Who is the mission led by?"",
              ""correct_answer"": ""Arizona State University"",
              ""wrong_answer"": """"
            },
            {
              ""question"": ""Has NASA sent a spacecraft to a metallic asteroid before ?"",
              ""correct_answer"": ""No"",
              ""wrong_answer"": ""Yes""
            },
            {
              ""question"": ""Who discovered the Psyche asteroid?"",
              ""correct_answer"": ""Annibale de Gasparis"",
              ""wrong_answer"": ""Galileo""
            },
            {
              ""question"": ""What is being sent to investigate Psyche?"",
              ""correct_answer"": ""spacecraft"",
              ""wrong_answer"": ""alien""
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
