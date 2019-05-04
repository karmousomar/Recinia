import { Injectable } from "../../lib-npm/angular/core/core";
import { Http, HttpModule, RequestOptions, Response, Headers } from "../../lib-npm/angular/http/http";
import { Router } from "../../lib-npm/angular/router/router";
import { Observable } from 'rxjs/Rx';
import { Login } from '../model/Login';

@Injectable()
export class LoginAuthenticationService {

    public headers: Headers;
    constructor(private http: Http) {

        this.http = http;
    }

    authentication(username,password){

        var model = { Username: username, Password: password };

        this.http.post("/Main/Login", model).map(res => res.toString()).subscribe(
            success => {
                window.location.href = "/LoggedIn/index";
            });

    }




}