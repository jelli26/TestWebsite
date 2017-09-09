//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  styleUrls: ['./app.component.css']
//})
//export class AppComponent {
//  title = 'app works!';
//}


import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    constructor(private _httpService: Http) { }
    apiAngularTestValues: string[] = ["Test","Values"];
    ngOnInit() {
        this._httpService.get('/api/angulartest').subscribe(angulartest => {
            this.apiAngularTestValues = angulartest.json() as string[];
        });
    }
}
