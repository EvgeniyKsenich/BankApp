import { Component } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

import { User } from './Modeles/User';

import { LoginService } from './Servises/LoginService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [LoginService]
})



export class AppComponent {
  User_:User = new User();
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  tokenKey:string = "accessToken";
  url:string = "localhost:62733";
  
  constructor(private loginService: LoginService){

  }

  login(){
    this.loginService.login(this.User_, this.url + "/token").subscribe((data: any) => {
      console.log(data);
  });
  }

}
