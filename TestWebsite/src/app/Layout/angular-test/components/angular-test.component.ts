import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
@Component({
    selector: 'angular-test',
    templateUrl: './angular-test.component.html',
    styleUrls: ['./angular-test.component.css']
})
export class AngularTestComponent implements OnInit {
    constructor(private _httpService: Http) { }
    apiAngularTestValues: string[] = ["Test","Values"];
    ngOnInit() {
        this._httpService.get('/api/angulartest').subscribe(angulartest => {
            this.apiAngularTestValues = angulartest.json() as string[];
        });
    }
}
