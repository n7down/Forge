import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'create-battery',
    templateUrl: './create-battery.component.html',
    styleUrls: ['./create-battery.component.css']
})
export class CreateBatteryComponent {
    private baseUrl: string;
    private name: string;
    private lipoVoltage: string;
    private mah: number;
    private cRating: string;
    private plugType: string;
    private weight: string;
    private dimension: string;
    private link: string;
    
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
        this.baseUrl = baseUrl;
    }

    create() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify({ name: this.name, lipoVoltage: this.lipoVoltage, mah: this.mah, cRating: this.cRating, plugType: this.plugType, weight: this.weight, dimension: this.dimension, link: this.link });
        console.log("creating: ", body);
        this.http.post(this.baseUrl + 'api/v1/battery/', body, options).subscribe(result => {
            this.router.navigate(['/batteries']);
        }, error => console.error(error));
    }
}
