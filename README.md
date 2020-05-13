# PeopleApp

The project demonstrates consuming HttpClient API in .NET Core 3.1 Web API project, and then using it as service to further re-expose as [baseurl]/api/people for a client application to consume some processed data.

The endpoint API The [baseurl]/api/people returns Cat names categorised by their owner gender (lately realised the api could have been better named something like api/gendercats:) )

# Demo Task Specification

http://agl-developer-test.azurewebsites.net/

## API consumed 

http://agl-developer-test.azurewebsites.net/people.json

## New API for client application

[baseurl]/api/people

The above returns Cat names categorised by their owner gender

http://agl-developer-test.azurewebsites.net/people.json

## Getting Started

To run the project you will need:
.NET CORE 3.1
Angular version: 9.1.3

## Prerequisites MUST

Before you run the PeopleApp-SPA client project, please ensure to update the http API URL port number to match the People.API:

Open /PeopleApp-SPA/src/app/people/people.component.ts and update the localhost port number as below based on .NET application server localhost port.

```
getPeople(){
    this.http.get('http://localhost:5000/api/people').subscribe(response => {
      this.peoples = response;
    }, error => {
      console.log(error);
    });
  }
```
