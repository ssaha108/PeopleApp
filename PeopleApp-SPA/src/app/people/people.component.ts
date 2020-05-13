import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {
  peoples: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPeople();
  }

  getPeople(){
    this.http.get('http://localhost:53115/api/people').subscribe(response => {
      this.peoples = response;
    }, error => {
      console.log(error);
    });
  }

}
