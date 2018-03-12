import { Component } from '@angular/core';
import { User } from './Models/User';
import { Transaction } from './Models/Transaction';
import { UserServises } from './Servises/UserServises';
import { TransactionServises } from './Servises/TransactionServises';

@Component({
  selector: 'app-root',
  templateUrl: './template/app.component.html',
  styleUrls: ['./style/app.component.css'],
  providers: [UserServises, TransactionServises]
})

export class AppComponent {
  private UserServises_:UserServises;
  private TransactionServises_:TransactionServises;
  private static ApiServerAddress:string = "http://localhost:62733";


  AppComponent(UserServis:UserServises, TransactionServises:TransactionServises){
    this.UserServises_ = UserServis;
    this.TransactionServises_ = TransactionServises;
  }

  public Login(){

  }

  public Logout(){
    
  }

  private GetKey(){

  }
  private SetKey(){

  }
}
