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
              ""wrong_answer"": ""Metal""
            },
            {
              ""question"": ""When is the launch of the Psyche spacecraft from Cape Canaveral, Florida?"",
              ""correct_answer"": ""2022"",
              ""wrong_answer"": ""2021""
            },
            {
              ""question"": ""Who has been to the Psyche asteroid?"",
              ""correct_answer"": ""No one"",
              ""wrong_answer"": ""Some astronauts""
            },
            {
              ""question"": ""Does the Psyche asteroid have gravity?"",
              ""correct_answer"": ""Yes"",
              ""wrong_answer"": ""No""
            },
            {
              ""question"": ""How long with the spacecraft fly?"",
              ""correct_answer"": ""3.4 years"",
              ""wrong_answer"": ""3.4 hours""
            },
            {
              ""question"": ""What is the size of the spacecraft?"",
              ""correct_answer"": ""Roughly the size of one tennis court"",
              ""wrong_answer"": ""Roughly the size of one football field""
            },
            {
              ""question"": ""What are the terrestrial planets?"",
              ""correct_answer"": ""Mercury, Venus, Earth and Mars"",
              ""wrong_answer"": ""Mercury, Jupiter, Earth and Mars""
            },
            {
              ""question"": ""When will the spacecraft flyby Mars?"",
              ""correct_answer"": ""2023"",
              ""wrong_answer"": ""2024""
            },
            {
              ""question"": ""How many phases does the Psyche mission have?"",
              ""correct_answer"": ""Four"",
              ""wrong_answer"": ""Five""
            },
            {
              ""question"": ""When did we discover what Psyche is made of?"",
              ""correct_answer"": ""2010"",
              ""wrong_answer"": ""1990""
            },
            {
              ""question"": ""When was the Psyche mission selected by NASA?"",
              ""correct_answer"": ""Jan 4, 2017"",
              ""wrong_answer"": ""Mar 4, 2013""
            },
            {
              ""question"": ""What company built the spacecraft?"",
              ""correct_answer"": ""Maxar Technologies"",
              ""wrong_answer"": ""SpaceX""
            },
            {
              ""question"": ""What will happen at the end of the mission?"",
              ""correct_answer"": ""The spacecraft will stay in orbit around Psyche"",
              ""wrong_answer"": ""The spacecraft will return to Earth""
            },
            {
              ""question"": ""What is Psyche orbiting?"",
              ""correct_answer"": ""The Sun"",
              ""wrong_answer"": ""Jupiter""
            },
            {
              ""question"": ""Who is the mission led by?"",
              ""correct_answer"": ""Arizona State University"",
              ""wrong_answer"": ""University of Arizona""
            },
            {
              ""question"": ""How many times has NASA investigated a planet made of metal before?"",
              ""correct_answer"": ""Never"",
              ""wrong_answer"": ""Twice""
            },
            {
              ""question"": ""What is being sent to Psyche to investigate?"",
              ""correct_answer"": ""Spacecraft"",
              ""wrong_answer"": ""Astronaut""
            },
            {
              ""question"": ""Who discovered the Psyche asteroid?"",
              ""correct_answer"": ""Annibale de Gasparis"",
              ""wrong_answer"": ""Galileo Galilei""
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