import { NgModule } from '../lib-npm/angular/core';
import { BrowserModule } from "../lib-npm/angular/platform-browser";
import { AppComponent } from './app.component';

@NgModule({
    imports: [BrowserModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }