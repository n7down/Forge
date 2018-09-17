import { Component, Inject } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'batteries',
    templateUrl: './batteries.component.html',
    styleUrls: ['./batteries.component.css']
})
export class BatteriesComponent {
    public batteries: Battery[] = [];
    private baseUrl: string;
    private http: Http;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.http = http;
        this.getData();
    }
    
    getData() {
		this.http.get(this.baseUrl + 'api/v1/battery').subscribe(result => {
            this.batteries = result.json() as Battery[];
        }, error => console.error(error));
    }

    remove(id: string) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        this.http.delete(this.baseUrl + 'api/v1/battery/' + id, options).subscribe(result => {
            this.getData();
        }, error => console.error(error));
    }
}

interface Battery {
    id: string;
    name: string;
    lipoVoltage: string;
    mah: string;
    cRating: string;
    plugType: string;
    weight: string;
    dimension: string;
    link: string;
}
