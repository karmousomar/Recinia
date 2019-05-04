import { Component } from "../lib-npm/angular/core";
import { Http, Headers, RequestOptions } from "../lib-npm/angular/http";
import { Router } from "../lib-npm/angular/router";
import { Login } from './model/login';
import { LoginAuthenticationService } from './services/login.service';
import "rxjs/Rx";

@Component({
    selector: 'core-app',
    templateUrl: "app/login/login.component.html",
    providers: [
        [LoginAuthenticationService]
    ]
})
export class AppComponent {
  
    model = new Login("", "");

    constructor(private http: Http, private dataService: LoginAuthenticationService) {

        console.log("Form Component Start");
    }

    authentication(username,password){
       
        this.dataService.authentication(username,password);
      
    }


}

