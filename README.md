# ChuckSWAPI
#Introduction

This document specifies how the ChuckSWAPI API should be used and consumed. The API comes with three endpoints
  1.  The chuck endpoint
  2.  The swapi endpoint
  3.  The search endpoint


| Method     |URL                              | Description                                                           |
| ---------- | -----------------------             | ----------------------------------------------------------------------|
| GET        | /chuck/categories                   | Retrieves all the joke categories                                     |
|            |                                     |                                                                       |
| GET        | /chuck/randomJoke                   | Retrieves a random joke                                               |
|            |                                     |                                                                       
| GET        | /swapi/people                       | Retrieves all the Star Wars People by page number    (defaulting to page 1)                  
|            |                                     |                                                 
|            |                                     |                                                                       
| GET        | /search/SearchSWApi/{searchTerm}    | Retrieves the appropriate results in the StarWars API based on a search term              
|            |                                     |                                                
|            |                        |                                                                       |
| GET        | /search/SearchChuck/{searchTerm}    |Retrieves the appropriate results in the StarWars API based on a search term                  |
|            |                        |                                                 |
