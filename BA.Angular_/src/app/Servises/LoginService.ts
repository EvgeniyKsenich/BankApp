import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { User } from '../Modeles/User';

@Injectable()
export class LoginService {

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
     
    constructor(private http: HttpClient) {   }


    login(user:User, url:string){
        return this.http
        .post(url, {
            username:user.Username,
            password:user.Password
        }, {
            headers: this.httpOptions.headers
        });
    }
}